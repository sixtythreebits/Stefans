using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Core.CM
{
    public class ADNTransaction : CoreObjectBase
    {
        #region Properties

        public string[] TransactionResponseArray { get; set; }

        public bool IsTransactionSuccessful
        {
            get
            {
                return TransactionResponseArray != null &&
                       TransactionResponseArray.Length > 2 && 
                       TransactionResponseArray[0] == "1" &&
                       TransactionResponseArray[2] == "1";
            }
        }

        public bool IsCardNumberValid
        {
            get
            {
                return TransactionResponseArray != null &&
                       TransactionResponseArray.Length > 2 &&
                       TransactionResponseArray[2] != "6"; 
            }
        }

        public bool IsExpDateValid
        {
            get
            {
                return TransactionResponseArray != null &&
                       TransactionResponseArray.Length > 2 &&
                       TransactionResponseArray[2] != "7"; 
            }
        }

        public bool IsCCVValid
        {
            get
            {
                return TransactionResponseArray != null &&
                       TransactionResponseArray.Length > 2 &&
                       TransactionResponseArray[2] != "78";
            }
        }

        #endregion

        #region Methods

        public void Create(int UserID, long ADNTransactionID, string RequestStr, string ResponseStr)
        {
            TryExecute(db =>
            {
                int? id = null;
                db.tsp_ADNTransactions(0, ref id, UserID, null, ADNTransactionID, RequestStr, ResponseStr);
            }, Logger: string.Format("Create(UserID = {0}, ADNTransactionID = {1}, RequestStr = {2}, ResponseStr = {3})", UserID, ADNTransactionID, RequestStr, ResponseStr));
        }

        public async Task SubmitPaymentTransactionAsync(string ADNApiUrl, string PostString, char Delimiter)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ADNApiUrl);
                request.Method = "POST";
                request.ContentLength = PostString.Length;
                request.ContentType = "application/x-www-form-urlencoded";

                using (var sw = new StreamWriter(await request.GetRequestStreamAsync()))
                {
                    await sw.WriteAsync(PostString);
                    sw.Close();
                }

                string result;
                using (var response = (HttpWebResponse)(await request.GetResponseAsync()))
                using (var responseStream = new StreamReader(response.GetResponseStream()))
                {
                    result = await responseStream.ReadToEndAsync();
                }

                TransactionResponseArray = result.Split(Delimiter);
            }
            catch (Exception ex)
            {
                ErrorProcessing(string.Format("SubmitPaymentTransactionAsync(ADNApiUrl = {0}, PostString = {1}, Delimiter = {2})", ADNApiUrl, PostString, Delimiter), ex);
            }
        }

        #endregion
    }
}
