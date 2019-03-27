using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Core.Models;
using Komis.Core.Repositories;

namespace Komis.Infrastructure.Services
{
    public class CarService : ICarService
    {

        private readonly ICarRepository _carReposotory;

        public CarService(ICarRepository carReposotory)
        {
            _carReposotory = carReposotory;
        }

        public async Task AddAsync(Guid id, string Brand, string model, int yearofproduction, string milage, string capacity, string fueltype, string power, string description, decimal price, string pictureurl, string thumbnailurl, bool iscaroftheweek, bool isinacentral)
        {
            var car = await _carReposotory.GetAsync(id);
            if (car != null)
            {
                throw new Exception($"Car with id: '{id}' already exists.");
            }
            car = new Car(id, Brand, model, yearofproduction, milage, capacity, fueltype, power, description, price, pictureurl, thumbnailurl, iscaroftheweek, isinacentral);
           
            await _carReposotory.AddAsync(car);
        }

        public async Task<IEnumerable<Car>> BrowseAsync()
        => await _carReposotory.GetAllAsync();
           

        public async Task DeleteAsync(Guid id)
        => await _carReposotory.DeleteAsync(id);

        public async Task<Car> GetAsync(Guid carId)
        {
            var car = await _carReposotory.GetAsync(carId);
            return car;
        }
    }
}
