using Komis.Core.ViewModels;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Komis.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ICarService _carService;

        public HomeController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var samochody = await _carService.BrowseAsync();
            samochody.OrderBy(s => s.Brand);

            var homeViewModel = new HomeViewModel()
            {
                Title = "Przegląd samochodów",
                CarList = samochody.ToList()
            }; 
         
            return View(homeViewModel);
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
