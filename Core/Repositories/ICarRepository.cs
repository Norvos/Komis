using Komis.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Komis.Core.Repositories
{
    public interface ICarRepository : IRepository
    {
        Task<Car> GetAsync(Guid id);
        Task<IEnumerable<Car>> GetAllAsync();
        Task AddAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(Guid id);
    }
}
