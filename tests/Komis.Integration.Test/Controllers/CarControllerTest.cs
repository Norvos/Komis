using FluentAssertions;
using Komis.Core.Models;
using Komis.Infrastructure.Commands.Car;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Komis.Integration.Test.Controllers
{
    public class CarControllerTest : ControllerTestsBase
    {

        [Fact]
        public async Task Add_new_car_should_be_successful()
        {
            var car = new Car
            {
                Brand = "TEST",
                Capacity = "TEST",
                Description = "TEST",
                FuelType = "TEST",
                Milage = "TEST",
                Model = "TEST",
                Power = "TEST",
                Price = 0,
                YearOfProduction=2019
            };

            var stream = File.OpenRead("test.jpg");

            IFormFile image = new FormFile(stream, 0, stream.Length, "Image", Path.GetFileName(stream.Name))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpg"
            };
           
            var command = new AddVehicle()
            {
                Car = car,
                Image = image
            };


            var payload = GetPayload(command);
            var response = await Client.PostAsync("http://localhost/Car/AddNewCarFromJSON", payload);

            response.StatusCode.Should().Be(HttpStatusCode.Redirect);
        }

  
    }

   


}
