using System.Net;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using Komis.Core.Models;
using Komis.Core.ViewModels;
using System;
using System.Linq;
using System.IO;

namespace Komis.Integration.Test.Controllers
{
    public class HomeControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task Given_invalid_id_car_should_not_exist()
        {
            var id = 12345;

            var response = await Client.GetAsync($"Home/Details/{id}");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Index_should_return_cars_list()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await Client.GetAsync("/Home/IndexGetJson");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

             var stringResponse = await httpResponse.Content.ReadAsStringAsync();
             var players = JsonConvert.DeserializeObject<IEnumerable<Car>>(stringResponse);

              Assert.Contains(players, p => p.Brand== "Citroen");
              Assert.Contains(players, p => p.Brand== "Fiat");

           
        }

    }
}
