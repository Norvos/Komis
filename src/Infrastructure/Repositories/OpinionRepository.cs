using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Core.Models;
using Komis.Core.Repositories;
using Komis.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Komis.Infrastructure.Repositories
{
    public class OpinionRepository : IOpinionRepository
    {
        private readonly DBContext _context;
        private readonly IMemoryCache _cache;

        public OpinionRepository(DBContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
      
        public async Task AddAsync(Opinion opinion)
        {
            opinion.CreatedAt = DateTime.UtcNow;
            await _context.Opinions.AddAsync(opinion);
            await _context.SaveChangesAsync();

            _cache.Remove("numberOfOpinions");
        }

        public async Task DeleteAsync(Guid id)
        {
            var opinion = await GetAsync(id);
            _context.Opinions.Remove(opinion);
            await _context.SaveChangesAsync();

            _cache.Remove("numberOfOpinions");
        }

        public async Task<IEnumerable<Opinion>> GetAllRequiredAsync()
        {
            var opinions = await _context.Opinions
            .Where(e => e.WaitingForAnAnswer == true)
            .OrderBy(x => x.CreatedAt)
            .ToListAsync();
            
            return opinions;
            
        }

        public async Task<Opinion> GetAsync(Guid id)
          => await _context.Opinions.SingleOrDefaultAsync(x => x.ID == id);

        public async Task<int> GetNumberOfRequiredAsync()
        {
            int? number = _cache.Get<int?>("numberOfOpinions");

            if (number == null)
            {
                var opinions = await GetAllRequiredAsync();
                _cache.Set("numberOfOpinions", opinions.Count() , TimeSpan.FromHours(2));
                return opinions.Count();
            }

            return (int)number;
        }

        public async Task Update(Opinion opinion)
        {
             opinion.UpdatedAt = DateTime.UtcNow;
            _context.Opinions.Update(opinion);
            await _context.SaveChangesAsync();

            _cache.Remove("numberOfOpinions");
        }
    }
}
