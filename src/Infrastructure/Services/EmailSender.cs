using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmail(string to, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("testCsharp2019@gmail.com");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("testCsharp2019@gmail.com", "Komis123");
                    smtp.EnableSsl = true;
                    //await smtp.SendMailAsync(mail);
                }
            }
        }
    }
}
