using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Commands.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Handlers.User
{
    public class CreateUserHandler:ICommandHandler<CreateUser>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CreateUserHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task HandleAsync(CreateUser command)
        {
            var user = new IdentityUser()
            {
                UserName = command.Username,
                Email = command.Email
            };

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                throw new Exception("Nazwa użytkownika lub hasło są niewłaściwe");
            }
        }

    }
}
