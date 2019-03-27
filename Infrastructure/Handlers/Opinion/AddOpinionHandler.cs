using Komis.Core.Repositories;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Commands.Opinion;
using Komis.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Handlers.Opinion
{
    public class AddOpinionHandler : ICommandHandler<AddOpinion>
    {
        private readonly IOpinionService _opinionService;

        public AddOpinionHandler(IOpinionService opinionService)
        {
            _opinionService = opinionService;
        }

        public async Task HandleAsync(AddOpinion command)
        {
            await _opinionService.AddAsync(command.ID, command.Email, command.Username, command.Message, command.WaitingForAnAnswer);
        }
    }
}
