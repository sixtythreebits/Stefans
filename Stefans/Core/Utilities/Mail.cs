using System.Net;
using System.Net.Mail;
using System.Text;
using SystemBase;

namespace Core.Utilities
{
    public class Mail : ObjectBase
    {
        #region Properties

        readonly string _smtp = "smtp.gmail.com";
        readonly string _username = "emma@63bits.com";
        readonly string _password = "1qaz!QAZ";
        readonly int _port = 587;
        string _from = "emma@63bits.com";
        readonly bool _enableSsl = true;

        public string From
        {
            set { _from = value; }
            get { return _from; }
        }
        #endregion Properties

        #region Constructors
        public Mail()
        {
        }

        public Mail(string SMTP, int Port, string Username, string Password, string From, bool EnableSSL)
        {
            _smtp = SMTP;
            _username = Username;
            _password = Password;
            _port = Port;
            _from = From;
            _enableSsl = EnableSSL;
        }
        #endregion Constructors

        #region Methods

        public void Send(string To, string Subject, string Body)
        {
            TryExecute(() =>
            {
                var message = new MailMessage { From = new MailAddress(From) };
                message.To.Add(To);
                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                message.SubjectEncoding = Encoding.UTF8;

                var client = new SmtpClient(_smtp, _port)
                {
                    Credentials = new NetworkCredential(_username, _password),
                    EnableSsl = _enableSsl
                };

                client.Send(message);
            }, Logger: string.Format("Send(To = {0}, Subject = {1}, Body = {2})", To, Subject, Body));
        }

        #endregion Methods
    }
}
