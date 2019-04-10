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
        public async Task when_calling_get_async_and_user_does_not_exist_it_should_invoke_user_repository_get_async()
        {
            var carRepositoryMock = new Mock<ICarRepository>();
            
            var carService = new CarService(carRepositoryMock.Object);

            var id = new Guid();
            await carService.GetAsync(id);

            carRepositoryMock.Setup(x => x.GetAsync(id))
                              .ReturnsAsync(() => null);

            carRepositoryMock.Verify(x => x.GetAsync(It.IsAny<Guid>()), Times.Once());
        }
    }
}
