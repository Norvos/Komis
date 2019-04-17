using Komis.Core.Models;
using Komis.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Repositories
{
    public interface IImageRepository : IRepository
    {
        Task RemoveAsync(Guid id);
        Task<Image> GetAsync(Guid id);
        Task AddAsync(Image image);
        Task AddAsync(IEnumerable<Image> images);
    }
}
