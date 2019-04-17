using Komis.Core.Models;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Commands.Car;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Komis.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarController : ApiControllerBase
    {
        private readonly IImageService _imageService;

        // GET: /<controller>/
        public CarController(ICommandDispatcher commandDispatcher, IEmailSender emailSender, ICarService carService, IImageService imageService)
        : base(commandDispatcher, emailSender, carService)
        {
            _imageService = imageService;
        }
     

        public IActionResult AddNewCar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCarFromJSON([FromBody]AddVehicle command)
            => await AddNewCar(command);
       

        [HttpPost]
        public async Task<IActionResult> AddNewCar(AddVehicle command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            try
            {
                await DispatchAsync(command);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("addError", e.Message);
                return View(command);
            }

         
            return RedirectToAction("AddedSuccessful");
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

            return RedirectToAction("EditedSuccessful");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _carService.DeleteAsync(id); 
            //I like my cars and I don't want to delete them :(

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> EditGallery(Guid id)
        {
            var car = await _carService.GetAsync(id);
            
            return View(car.Images);
        }

        public async Task<IActionResult> DeletePhoto(Guid id)
        {
            var img = await _imageService.GetAsync(id);

            await _imageService.RemoveAsync(id);

            //return RedirectToAction("EditGallery", img.CarID);

            return RedirectToAction("EditGallery", new { id = img.CarID });
        }
        public IActionResult EditedSuccessful()
        {
            return View();
        }

        public IActionResult AddedSuccessful()
        {
            return View();
        }
    }
}
