using System.Net;
using System.Net.Mail;

namespace ProjetoIntegrador4B.Helpers
{
    public class Email
    {
        public static int send(string adress, string body)
        {
            var fromAddress = new MailAddress("braianpi465@gmail.com", "Projeto");
            var toAddress = new MailAddress(adress, "Voce");
            const string fromPassword = "braian123**";
            const string subject = "Vacinacao COVID19 update";

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
                Body = body
            })
            {
                smtp.Send(message);
            }

            return 1;
        }
    }
}
