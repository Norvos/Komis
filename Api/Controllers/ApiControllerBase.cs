using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Komis.Api.Controllers
{
    public class ApiControllerBase : Controller
    {
        private readonly ICommandDispatcher CommandDispatcher;

        public ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            await CommandDispatcher.DispatchAsync(command);
        }
    }
}