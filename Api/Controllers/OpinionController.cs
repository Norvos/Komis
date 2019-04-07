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
       
        public OpinionController(IUserService userService, ICommandDispatcher commandDispatcher,IEmailSender emailSender, ICarService carService)
           : base(commandDispatcher, emailSender, carService)
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

        public async Task<IActionResult> SendSuccessful()
        {
            _emailSender.SendEmail(await GetEmailAddress(), $"{User.Identity.Name} dziękujemy za opinię",Messages.Opinion);
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
    }
}