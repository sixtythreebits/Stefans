using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Stefans.Models;

namespace Stefans.Reusable
{
    public class ADNAssistant
    {
        public static async Task SubmitPaymentTransactionAsync(decimal Amount, CardModel Card, AddressModel Billing)
        {
            const char delimiter = '|';
            var postValues = new Dictionary<string, string>
                {
                    {"x_login", ConfigAssistant.ADNLogin},
                    {"x_tran_key", ConfigAssistant.ADNTransactionKey},
                    {"x_version", "3.0"},
                    {"x_amount", Amount.ToString()},
                    //{"x_description", PI.Description},
                    {"x_card_num", Card.CardNumber},
                    {"x_exp_date", Card.Month + Card.Year},
                    {"x_card_code", Card.CCV},
                    {"x_first_name", Card.FirstName},
                    {"x_last_name ", Card.LastName},
                    {"x_city", Billing.City},
                    {"x_address", Billing.Address1},
                    //{"x_state", PI.State},
                    {"x_zip ", Billing.Zip},
                    //{"x_country", Billing.couy},
                    //{"x_customer_ip", PI.IP},
                    {"x_delim_data", "TRUE"},
                    {"x_delim_char", delimiter.ToString()},
                    {"x_relay_response", "FALSE"}
                };

            var sb = postValues.Aggregate(new StringBuilder(), (aggregated, current) => aggregated.AppendFormat("{0}={1}&", current.Key, HttpUtility.UrlEncode(current.Value)));

            var postString = sb.ToString();

            var request = (HttpWebRequest)WebRequest.Create(ConfigAssistant.ADNApiUrl);
            request.Method = "POST";
            request.ContentLength = postString.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            using (var sw = new StreamWriter(await request.GetRequestStreamAsync()))
            {
                await sw.WriteAsync(postString);
                sw.Close();
            }

            string result;
            using (var response = (HttpWebResponse)(await request.GetResponseAsync()))
            using (var responseStream = new StreamReader(response.GetResponseStream()))
            {
                result = await responseStream.ReadToEndAsync();
            }

            var ADNTransactionID = string.Empty;
            var resultArray = result.Split(delimiter);
            if (resultArray.Length > 6)
            {
                ADNTransactionID = resultArray[6];
            }
        }
    }
}