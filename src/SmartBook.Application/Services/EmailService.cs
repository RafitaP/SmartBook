using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace SmartBook.Persistence.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var emailSettings = _config.GetSection("EmailSettings");
            var from = emailSettings["From"];
            var password = emailSettings["Password"];
            var smtp = emailSettings["SmtpServer"];
            var port = int.Parse(emailSettings["Port"]);

            using (var client = new SmtpClient(smtp, port))
            {
                client.Credentials = new NetworkCredential(from, password);
                client.EnableSsl = true;

                var mail = new MailMessage(from, to, subject, body)
                {
                    IsBodyHtml = true
                };

                await client.SendMailAsync(mail);
            }
        }
    }
}
