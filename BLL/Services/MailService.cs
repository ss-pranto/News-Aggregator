using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MailService
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                var fromAddress = new MailAddress("suppriosaha2002@Gmail.com", "News_aggrigetor");
                var toAddress = new MailAddress(toEmail);
                string fromPassword = "idwm sxxa tgcp refq"; // Use App Password (not your Gmail password)

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }
                
            }
            catch (Exception ex)
            {
                // Handle error
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
