using Komis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Services
{
    public interface ICarService : IService
    {
        Task<Car> GetAsync(Guid opinionId);
        Task<IEnumerable<Car>> BrowseAsync();
        Task AddAsync(Guid id, string Brand, string model,int yearofproduction, string milage, string capacity,string fueltype,
        string power, string description, decimal price, string pictureurl, string thumbnailurl, bool iscaroftheweek,bool isinacentral);
        Task DeleteAsync(Guid id);
    }
}
