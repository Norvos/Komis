using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Infrastructure.EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Komis.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DBContext _context;

        public UserRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IdentityUser>> GetAllAsync()
        => await _context.Users.ToListAsync();

        public async Task<IdentityUser> GetAsync(Guid id)
        => await _context.Users.SingleOrDefaultAsync(x => x.Id == id.ToString());

        public async Task<IdentityUser> GetAsync(string username)
        => await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);

        public async Task UpdateAsync(IdentityUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
       
    }
}
