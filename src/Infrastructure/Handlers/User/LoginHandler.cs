using Komis.Api.Controllers;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Commands.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Handlers.User
{
    public class LoginHandler:ICommandHandler<Login>
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginHandler(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task HandleAsync(Login command)
        {
            var user = await _userManager.FindByNameAsync(command.Username);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, command.Password, false, false);

                if (!result.Succeeded)
                {
                    throw new Exception("Nazwa użytkownika lub hasło są niewłaściwe");
                }
            }
            else throw new Exception("Nazwa użytkownika lub hasło są niewłaściwe");

        }

    }
}
