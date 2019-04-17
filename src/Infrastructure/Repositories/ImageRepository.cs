using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Komis.Core.Models;
using Komis.Infrastructure.EF;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Komis.Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly DBContext _context;

        private readonly ICarService _carService;

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMemoryCache _cache;

        public ImageRepository(DBContext context, ICarService carService, IHostingEnvironment hostingEnvironment, IMemoryCache cache)
        {
            _context = context;
            _carService = carService;
            _hostingEnvironment = hostingEnvironment;
            _cache = cache;
        }

        public async Task AddAsync(Image image)
        {
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(IEnumerable<Image> images)
        {
            foreach (var img in images)
            {
                await AddAsync(img);
            }
          
        }

        public async Task<Image> GetAsync(Guid id)
         => await _context.Images.SingleOrDefaultAsync(x => x.ID == id);

        public async Task RemoveAsync(Guid id)
        {
            var img = await GetAsync(id);
            var car = await _carService.GetAsync(img.CarID);
            car.DeleteImage(id);

            try
            {
                var imagesFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(imagesFolder, img.Name);
                File.Delete(filePath);

            }
            catch (Exception ex) { } //TODO
          
            _context.Images.Remove(img);
            await _context.SaveChangesAsync();

            _cache.Remove("cars");
        }
    }
}
