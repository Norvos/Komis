using Komis.Core.Models;
using Komis.Core.ViewModels;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Komis.Api.Controllers
{
    [Authorize(Roles="Admin")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IHostingEnvironment _hostingEnvironment;
        // GET: /<controller>/

        public CarController(ICarService carService, IHostingEnvironment hostingEnvironment)
        {
            _carService = carService;
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
                vm.Car.ThumbnailURL = filePath;
            }

            

            if (!vm.Car.Milage.Contains("km")) vm.Car.Milage += " km";
            if (!vm.Car.Power.Contains("KM")) vm.Car.Power += " KM";

            await _carService.AddAsync(vm.Car);
            return View();
        }
    }
}
