using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Commands.Car;
using Komis.Infrastructure.Extensions;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
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
                AddImageToCar.Add(_hostingEnvironment, command.Images, command.Car);
            }

            if (!command.Car.Milage.Contains("km")) command.Car.Milage += " km";
            if (!command.Car.Power.Contains("KM")) command.Car.Power += " KM";

            await _carService.AddAsync(command.Car);
       }

          
     }
 }

