using System;
using System.Threading.Tasks;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Commands.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Komis.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(ICommandDispatcher commandDispatcher,
            SignInManager<IdentityUser> signInManager)
        : base(commandDispatcher)
        {
            _signInManager = signInManager;
        }

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
