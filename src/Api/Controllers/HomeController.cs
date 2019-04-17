using Komis.Api.Controllers;
using Komis.Core.Models;
using Komis.Core.ViewModels;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Komis.Controllers
{
    [AllowAnonymous]
    public class HomeController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;

        public HomeController(ICommandDispatcher commandDispatcher, IEmailSender emailSender, ICarService carService, IMemoryCache cache)
        :base(commandDispatcher, emailSender, carService)
        {
            _cache = cache;
        }
        

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var cars = await GetCars();

            var homeViewModel = new HomeViewModel()
            {
                Title = "Przegląd samochodów",
                CarList = cars.ToList()
            };

            return View(homeViewModel);
        }

        public async Task<string> IndexGetJson()
        {
            var cars = await GetCars();
           
            return  JsonConvert.SerializeObject(cars);
        }

        private async Task<IEnumerable<Car>> GetCars()
        {
            var cars = _cache.Get<IEnumerable<Car>>("cars");

            if (cars == null)
            {
                cars = await _carService.BrowseAsync();
                _cache.Set("cars", cars, TimeSpan.FromHours(2));
            }

            return cars;
        }


        public async Task<IActionResult> Details(Guid id)
        {
            var samochod = await _carService.GetAsync(id);

            if (samochod == null)
                return NotFound();

            return View(samochod);     
        }
    }
}
