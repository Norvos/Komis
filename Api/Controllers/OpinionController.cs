using Komis.Api.Controllers;
using Komis.Core.Models;
using Komis.Core.Repositories;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Komis.Controllers
{
    [Authorize]
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
            await GetEmailAddress();
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
            return View();
        }

        private async Task GetEmailAddress()
        {
            var username = User.Identity.Name;

            if (!string.IsNullOrEmpty(username))
            {
                var user = await _userService.GetAsync(username);
                ViewData.Add("Email",user.Email);
            }
        }
    }
}