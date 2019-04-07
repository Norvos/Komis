using Komis.Api.Controllers;
using Komis.Core.Models;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Komis.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class OpinionController : ApiControllerBase
    {
        private readonly IUserService _userService;
 
        public OpinionController(IUserService userService, ICommandDispatcher commandDispatcher)
           : base(commandDispatcher)
        {
            _userService = userService;
        }

        //[HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData.Add("Email", await GetEmailAddress());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Opinion command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await DispatchAsync(command);

            return RedirectToAction("SendSuccessful");
        }

        public IActionResult SendSuccessful()
        {
            SendEmail();
            return View();
        }

        private async Task<string> GetEmailAddress()
        {
            var username = User.Identity.Name;

            if (!string.IsNullOrEmpty(username))
            {
                var user = await _userService.GetAsync(username);
  
                return user.Email;
            }
            return string.Empty;
        }

         private async Task SendEmail()
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("testCsharp2019@gmail.com");
                mail.To.Add(await GetEmailAddress());
                mail.Subject = "Dziękujemy";
                mail.Body = "Właśnie napisałeś opinię w serwisie Komis. " +
                            "Twoja opinia jest dla nas bardzo cenna. Jeśli zaznaczyłeś opcję 'Czekam na odpowiedź' odezwiemy się do Ciebie w ciągu " +
                            "7-dmiu dni roboczych. "+
                            "Dziękujemy, jesteśmy wdzięczni.";
                mail.IsBodyHtml = true; 
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("testCsharp2019@gmail.com", "Komis123");
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
        }
    }
}