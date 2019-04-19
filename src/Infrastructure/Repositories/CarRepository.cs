using Komis.Core.Models;
using Komis.Core.Repositories;
using Komis.Infrastructure.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Repositories
{

    public class CarRepository : ICarRepository
    {
        private readonly DBContext _context;
        private readonly IMemoryCache _cache;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CarRepository(DBContext context, IMemoryCache cache, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _cache = cache;
            _hostingEnvironment = hostingEnvironment;
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

            var images = _context.Images
                    .Where(e => e.CarID == car.ID)
                    .ToList();

            if (images != null)
            {
                foreach (var image in images)
                {
                    try
                    {
                        var imagesFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        var filePath = Path.Combine(imagesFolder, image.Name);
                        File.Delete(filePath);

                    } catch (Exception ex) { }
                   
                    _context.Remove(image);
                   
                }
            }
          
            _context.Cars.Remove(car);

            await _context.SaveChangesAsync();

            _cache.Remove("cars");
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            var cars = await _context.Cars.ToListAsync();

            foreach(var car in cars)
            {
                var images = _context.Images
                     .Where(e => e.CarID == car.ID)
                      .OrderBy(x => x.CreatedAt)
                     .ToList();

                if (images != null)
                {
                    foreach (var image in images)
                    {
                        car.AddImage(image);
                    }
                }

            }

         
            return cars;
        }

        public async Task<Car> GetAsync(Guid id)
        {
            var car = await _context.Cars.SingleOrDefaultAsync(x => x.ID == id);

            var images = await _context.Images
                    .Where(e => e.CarID == car.ID)
                    .ToListAsync();

            foreach (var image in images)
            {
                car.AddImage(image);
            }

            return car;
        }

        public async Task UpdateAsync(Car car)
        {
             car.UpdatedAt = DateTime.UtcNow;
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();

            _cache.Remove("cars");
        }
    }
}
