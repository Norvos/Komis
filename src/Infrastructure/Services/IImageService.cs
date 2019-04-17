using Komis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Services
{
   public interface IImageService :IService
    {
        Task RemoveAsync(Guid id);
        Task<Image> GetAsync(Guid id);
        Task AddAsync(Image image);
        Task AddAsync(IEnumerable<Image> images);

    }
}
