using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EmailHelper
{
    public class MailSender
    {
        public bool SendSaleEmail(string email, string url)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential("mbarank.dev@gmail.com", "4fO3Pqbqir2qx6Pp");
                smtpClient.EnableSsl = true;

                mailMessage.From = new MailAddress("mbarank.dev@gmail.com");

                mailMessage.To.Add($"{email}");

                mailMessage.Subject = "İndirim Mevcut!";
                mailMessage.Body = "<h2>İndirime gitmek için linkte tıklayın</h2><hr/>";
                mailMessage.Body += $"<a href={url}>TIKLA</a>";
                mailMessage.IsBodyHtml = true;

                smtpClient.Send(mailMessage);
                return true;
            }
            catch
            {

                return false;
            }

        }
    }
}
