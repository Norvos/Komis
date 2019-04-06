using Komis.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<IdentityUser> GetAsync(Guid id);
        Task<IdentityUser> GetAsync(string username);
        Task<IEnumerable<IdentityUser>> GetAllAsync();
        Task UpdateAsync(IdentityUser user);
    }
}
