using System;
using System.Threading.Tasks;
using Komis.Core.Models;
using Komis.Core.Repositories;
using Komis.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Komis.Infrastructure.Repositories
{
    public class OpinionRepository : IOpinionRepository
    {
        private readonly DBContext _context;

        public OpinionRepository(DBContext context)
        {
            _context = context;
        }
      
        public async Task AddAsync(Opinion opinion)
        {
             await _context.Opinions.AddAsync(opinion);
             await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var opinion = await GetOrFailAsync(id);
            _context.Opinions.Remove(opinion);
            await _context.SaveChangesAsync();
        }

        public async Task<Opinion> GetOrFailAsync(Guid id)
          => await _context.Opinions.SingleOrDefaultAsync(x => x.ID == id);

        public async Task UpdateAsync(Opinion opinion)
        {
            _context.Opinions.Update(opinion);
            await _context.SaveChangesAsync();
        }
    }
}
