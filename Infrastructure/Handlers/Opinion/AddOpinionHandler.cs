using Komis.Core.Models;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Services;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Handlers.AddOpinion
{
    public class AddOpinionHandler : ICommandHandler<Opinion>
    {
        private readonly IOpinionService _opinionService;

        public AddOpinionHandler(IOpinionService opinionService)
        {
            _opinionService = opinionService;
        }

        public async Task HandleAsync(Opinion command)
        {
            await _opinionService.AddAsync(command.ID, command.Email, command.Username, command.Message, command.WaitingForAnAnswer);
        }
    }
}
