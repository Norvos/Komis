using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<IdentityUser> GetAsync(Guid Id);
        Task<IdentityUser> GetAsync(string username);
        Task RemoveAsync(Guid Id);
        Task UpdateAsync(Guid Id);
    }
}
