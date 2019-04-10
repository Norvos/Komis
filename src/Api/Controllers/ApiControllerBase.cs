using System.Threading.Tasks;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Komis.Api.Controllers
{
    public class ApiControllerBase : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        protected readonly IEmailSender _emailSender;
        protected readonly ICarService _carService;
    
        public ApiControllerBase(ICommandDispatcher commandDispatcher, IEmailSender emailSender, ICarService carService)
        {
            _commandDispatcher = commandDispatcher;
            _emailSender = emailSender;
            _carService = carService;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            await _commandDispatcher.DispatchAsync(command);
        }
    }
}