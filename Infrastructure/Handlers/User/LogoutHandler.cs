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
    public class LogoutHandler:ICommandHandler<Logout>
    {
        private readonly SignInManager<IdentityUser> _signInManager;
      

        public LogoutHandler(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task HandleAsync(Logout command)
        {
            await _signInManager.SignOutAsync();
        }

    }
}
