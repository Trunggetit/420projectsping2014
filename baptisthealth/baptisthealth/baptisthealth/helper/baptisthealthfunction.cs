using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace baptisthealth.helper
{
    public class baptisthealthfunction
    {
        public void sendmail(string SenderName, string SenderAddress, string Message)
        {
            string username = "tdngo001";
            string password = "asdfjk123";
            NetworkCredential loginInfo = new NetworkCredential(username, password);
            MailMessage msg = new MailMessage();

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;

            string message = SenderName + " (" + SenderAddress + ") :<br /><br />" + Message;

            try
            {
                msg.From = new MailAddress("tdngo001@gmail.com", "My Website");
                msg.To.Add(new MailAddress(SenderAddress));
                msg.Subject = "Web Message";
                msg.Body = message;
                msg.IsBodyHtml = true;

                smtpClient.Send(msg);
            }
            catch (Exception)
            {
            }
        }
    }
}