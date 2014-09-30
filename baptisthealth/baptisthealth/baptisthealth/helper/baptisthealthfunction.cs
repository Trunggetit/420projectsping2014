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
            string username = "";
            string password = "";
            NetworkCredential loginInfo = new NetworkCredential(username, password);
            MailMessage msg = new MailMessage();

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;

            string message = SenderName + " (" + SenderAddress + ") has a message for you:<br /><br />" + Message;

            try
            {
                msg.From = new MailAddress("tdngo0003@gmail.com", "My Website");
                msg.To.Add(new MailAddress("tdngo0003@gmail.com"));
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