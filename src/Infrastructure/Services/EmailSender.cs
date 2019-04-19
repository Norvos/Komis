using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task SendEmail(string to, string subject, string body)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = _configuration["Email:Email"],
                    Password = _configuration["Email:Password"]
                };

                client.Credentials = credential;
                client.Host = _configuration["Email:Host"];
                client.Port = int.Parse(_configuration["Email:Port"]);
                client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    var builder = new StringBuilder();

                    using (var reader = File.OpenText("wwwroot/content/emailTemplate.html"))
                    {
                        builder.Append(reader.ReadToEnd());
                    }

                    builder.Replace("{{body}}", body);

                    emailMessage.To.Add(new MailAddress(to));
                    emailMessage.From = new MailAddress(_configuration["Email:Email"]);
                    emailMessage.Subject = subject;
                    emailMessage.Body = builder.ToString();
                    emailMessage.IsBodyHtml = true;
                    client.Send(emailMessage);
                }
            }
            await Task.CompletedTask;
        }
    }
}
