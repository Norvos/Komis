using Komis.Core.Models;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Commands.Car;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Handlers.AddOpinion
{
    public class AddVehicleHandler : ICommandHandler<AddVehicle>
    {
        private readonly ICarService _carService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AddVehicleHandler(ICarService carService, IHostingEnvironment hostingEnvironment)
        {
            _carService = carService;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task HandleAsync(AddVehicle command)
        {
            if (command.Image != null)
            {
                var fileName = Path.GetFileName(command.Image.FileName);
                var splitedFileName = fileName.Split('.');
                string uniqueName = splitedFileName[0].Replace(splitedFileName[0], Guid.NewGuid().ToString());

                uniqueName += ('.' + splitedFileName[1]);

                var images = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                var lib = Path.Combine(_hostingEnvironment.WebRootPath, "lib");
                var filePath = Path.Combine(images, uniqueName);
                command.Image.CopyTo(new FileStream(filePath, FileMode.Create));

                filePath = Path.GetRelativePath(lib, filePath);

                command.Car.PictureURL = filePath;
            }

            if (!command.Car.Milage.Contains("km")) command.Car.Milage += " km";
            if (!command.Car.Power.Contains("KM")) command.Car.Power += " KM";

            await _carService.AddAsync(command.Car);
        }
    }
}
