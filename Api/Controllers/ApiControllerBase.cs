using System.Threading.Tasks;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Komis.Api.Controllers
{
    public class ApiControllerBase : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        protected readonly IEmailSender _emailSender;

        public ApiControllerBase(ICommandDispatcher commandDispatcher, IEmailSender emailSender)
        {
            _commandDispatcher = commandDispatcher;
            _emailSender = emailSender;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            await _commandDispatcher.DispatchAsync(command);
        }
    }
}