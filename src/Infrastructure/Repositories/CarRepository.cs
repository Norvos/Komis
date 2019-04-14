using Komis.Core.Models;
using Komis.Core.Repositories;
using Komis.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Repositories
{

    public class CarRepository : ICarRepository
    {
        private readonly DBContext _context;
        private readonly IMemoryCache _cache;

        public CarRepository(DBContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task AddAsync(Car car)
        {
            car.CreatedAt = DateTime.UtcNow;
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            _cache.Remove("cars");
        }

        public async Task DeleteAsync(Guid id)
        {
            var car = await GetAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            _cache.Remove("cars");
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        => await _context.Cars.ToListAsync();

        public async Task<Car> GetAsync(Guid id)
        => await _context.Cars.SingleOrDefaultAsync(x => x.ID == id);

        public async Task UpdateAsync(Car car)
        {
            car.UpdatedAt = DateTime.UtcNow;
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();

            _cache.Remove("cars");
        }
    }
}
