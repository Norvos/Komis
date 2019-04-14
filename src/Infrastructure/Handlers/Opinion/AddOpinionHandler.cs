using Komis.Core.Models;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Services;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Handlers.AddOpinion
{
    public class AddOpinionHandler : ICommandHandler<Commands.Opinion.AddOpinion>
    {
        private readonly IOpinionService _opinionService;

        public AddOpinionHandler(IOpinionService opinionService)
        {
            _opinionService = opinionService;
        }

        public async Task HandleAsync(Commands.Opinion.AddOpinion command)
        {
            await _opinionService.AddAsync((Opinion)command);
        }
    }
}
