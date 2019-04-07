using Komis.Api.Controllers;
using Komis.Core.ViewModels;
using Komis.Infrastructure.Commands;
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
    public class HomeController : ApiControllerBase
    {
       
        public HomeController(ICommandDispatcher commandDispatcher, IEmailSender emailSender, ICarService carService)
        :base(commandDispatcher, emailSender, carService) {}
        

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
