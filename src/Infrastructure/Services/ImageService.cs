using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Core.Models;
using Komis.Infrastructure.Repositories;

namespace Komis.Infrastructure.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task AddAsync(Image image)
         => await _imageRepository.AddAsync(image);

        public async Task AddAsync(IEnumerable<Image> images)
        => await _imageRepository.AddAsync(images);

        public async Task<Image> GetAsync(Guid id)
        => await _imageRepository.GetAsync(id);

        public async Task RemoveAsync(Guid id)
        => await _imageRepository.RemoveAsync(id);
    }
}
