using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Komis.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<IdentityUser> GetAsync(Guid Id)
        => await _userRepository.GetAsync(Id);

        public async Task<IdentityUser> GetAsync(string username)
        => await _userRepository.GetAsync(username);

        public async Task RemoveAsync(Guid id)
        => await _userRepository.RemoveAsync(id);

        public async Task UpdateAsync(Guid id)
          => await _userRepository.UpdateAsync(id);

    }
}
