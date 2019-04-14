using Komis.Core.Models;
using Komis.Core.Repositories;
using Komis.Infrastructure.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Komis.Unit.Tests.Services
{
    public class CarServiceTest
    {
        [Fact]
        public async Task when_calling_get_async_and_car_does_not_exist_it_should_invoke_car_repository_get_async()
        {
            var carRepositoryMock = new Mock<ICarRepository>();
            
            var carService = new CarService(carRepositoryMock.Object);

            var id = Guid.NewGuid();
            await carService.GetAsync(id);

            carRepositoryMock.Setup(x => x.GetAsync(id))
                              .ReturnsAsync(() => null);

            carRepositoryMock.Verify(x => x.GetAsync(It.IsAny<Guid>()), Times.Once());
        }

        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var carRepositoryMock = new Mock<ICarRepository>();
            var carService = new CarService(carRepositoryMock.Object);

            await carService.AddAsync(Guid.NewGuid(), "TEST", "TEST", 2019, "TEST", "TEST", "TEST", "TEST", "TEST", 0, "test.jpg");

            carRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Car>()), Times.Once);
        }

    }
}
