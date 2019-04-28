using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Commands.Car;
using Komis.Infrastructure.Extensions;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Handlers.Car
{
    public class AddPhotosHandler : ICommandHandler<EditVehicleGallery>
    {
        private readonly ICarService _carService;
        private readonly IHostingEnvironment _hostingEnvironment;
       
        public AddPhotosHandler(ICarService carService, IHostingEnvironment hostingEnvironment)
        {
            _carService = carService;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task HandleAsync(EditVehicleGallery command)
        {
            var car = await _carService.GetAsync(command.Car.ID);

            if (command.Images != null && car != null)
                AddImageToCar.Add(_hostingEnvironment, command.Images, car);

            await _carService.Update(car);
         }
    }
 }

    
   

