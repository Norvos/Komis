using Komis.Core.Models;
using Komis.Core.ViewModels;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Komis.Api.Controllers
{
    [Authorize(Roles="Admin")]
    public class CarController : ApiControllerBase
    {
       
        private readonly IHostingEnvironment _hostingEnvironment;
        // GET: /<controller>/

        public CarController(ICommandDispatcher commandDispatcher, IEmailSender emailSender, ICarService carService, IHostingEnvironment hostingEnvironment)
        : base(commandDispatcher, emailSender, carService)
        { 
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult AddNewCar()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddNewCar(AddCarVM vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }

            if (vm.Image != null)
            {
                var fileName = Path.GetFileName(vm.Image.FileName);
                var images = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                var lib = Path.Combine(_hostingEnvironment.WebRootPath, "lib");
                var filePath = Path.Combine(images, fileName);
                vm.Image.CopyTo(new FileStream(filePath, FileMode.Create));

                filePath = Path.GetRelativePath(lib, filePath);

                vm.Car.PictureURL = filePath;
            }

            

            if (!vm.Car.Milage.Contains("km")) vm.Car.Milage += " km";
            if (!vm.Car.Power.Contains("KM")) vm.Car.Power += " KM";

            await _carService.AddAsync(vm.Car);
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var car = await _carService.GetAsync(id);

            if (car == null)
                return NotFound();

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Car car_edited)
        {
            if (!ModelState.IsValid)
                return View(car_edited);

            await _carService.Update(car_edited);
            return View(car_edited);
        }

    }
}
