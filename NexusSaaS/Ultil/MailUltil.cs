using System.Net;
using System.Net.Mail;

namespace NexusSaaS.Ultil
{
    public class MailUltil
    {
        public void SendEmail(string subject, string body, string receiverEmail, string receiverName)
        {
            var fromAddress = new MailAddress("from@gmail.com", "From FPT APTECH");
            var toAddress = new MailAddress(receiverEmail, "To " + receiverName);
            const string fromPassword = "fromPassword";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("phucvtd00502@fpt.edu.vn", "meomeo@#$")
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
    }
}
