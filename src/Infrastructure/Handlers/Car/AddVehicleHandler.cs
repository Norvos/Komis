using Komis.Core.Models;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Commands.Car;
using Komis.Infrastructure.EF;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Handlers.AddOpinion
{
    public class AddVehicleHandler : ICommandHandler<AddVehicle>
    {
        private readonly ICarService _carService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IImageService _imageService;

        public AddVehicleHandler(ICarService carService, IHostingEnvironment hostingEnvironment, IImageService imageService)
        {
            _carService = carService;
            _hostingEnvironment = hostingEnvironment;
            _imageService = imageService;
        }

        public async Task HandleAsync(AddVehicle command)
        {
           
            if (command.Images != null)
            {
                var filesize = 2048;
                var supportedTypes = new[] { "jpg", "png" };
                foreach (var image in command.Images)
                {
                    var fileExt = Path.GetExtension(image.FileName).Substring(1).ToLowerInvariant();

                    if (!supportedTypes.Contains(fileExt))
                    {
                        throw new Exception("Photos extension is invalid - only upload JPG/PNG files");
                    }
                    else if (image.Length > (filesize * 1024))
                    {
                        throw new Exception($"Photos size should be up to {filesize} KB");
                    }
                    else
                    {
                        string uniqueName = Guid.NewGuid().ToString() + '.' + fileExt;

                        var images = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        var lib = Path.Combine(_hostingEnvironment.WebRootPath, "lib");
                        var filePath = Path.Combine(images, uniqueName);

                        var id = Guid.Parse(Path.GetFileNameWithoutExtension(filePath));
                       
                        using (var stream = new FileStream(filePath, FileMode.CreateNew))
                        {
                            image.CopyTo(stream);
                        }

                        filePath = Path.GetRelativePath(lib, filePath);


                        if (!command.Car.Milage.Contains("km")) command.Car.Milage += " km";
                        if (!command.Car.Power.Contains("KM")) command.Car.Power += " KM";


                        command.Car.AddImage(filePath, uniqueName, id);

                    }
                }

                await _carService.AddAsync(command.Car);
               // await _imageService.AddAsync(command.Car.Images);
            }

          
        }
    }
}
