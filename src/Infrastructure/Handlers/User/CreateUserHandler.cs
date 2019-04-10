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

        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateUserHandler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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

            var roleCheck = await _roleManager.RoleExistsAsync("User");

            if (!roleCheck)
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }

            await _userManager.AddToRoleAsync(user, "User");


        }

    }
}
