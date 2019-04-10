using System;
using System.Threading.Tasks;
using Komis.Core.Models;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Commands.User;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Komis.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController : ApiControllerBase
    {

        public AccountController(ICommandDispatcher commandDispatcher, IEmailSender emailSender, ICarService carService)
        : base(commandDispatcher, emailSender, carService) { }


        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (!ModelState.IsValid)
                return View(login);

            try
            {
                await DispatchAsync(login);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("loginError", e.Message);
                return View(login);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: /<controller>/
        public IActionResult Register()
        {
            return View(new CreateUser());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterFromBody([FromBody]CreateUser createUser)
        => await Register(createUser);
        

        [HttpPost]
        public async Task<IActionResult> Register(CreateUser createUser)
        {
            if (!ModelState.IsValid)
               return View(createUser);

            try
            {
                await DispatchAsync(createUser);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("registerError", e.Message);
                return View(createUser);
            }

            _emailSender.SendEmail(createUser.Email, $"{createUser.Username} dziękujemy za rejestrację", Messages.Register);
            return RedirectToAction("Index", "Home"); 
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await DispatchAsync(new Logout());
            return RedirectToAction("Index", "Home");
        }
    }
}
