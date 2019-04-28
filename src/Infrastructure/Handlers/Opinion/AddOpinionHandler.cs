using AutoMapper;
using Komis.Core.Models;
using Komis.Infrastructure.Commands;
using Komis.Infrastructure.Services;
using System.Threading.Tasks;

namespace Komis.Infrastructure.Handlers.AddOpinion
{
    public class AddOpinionHandler : ICommandHandler<Commands.Opinion.AddOpinion>
    {
        private readonly IOpinionService _opinionService;
        private readonly IMapper _mapper;


        public AddOpinionHandler(IOpinionService opinionService, IMapper mapper)
        {
            _opinionService = opinionService;
            _mapper = mapper;
        }

        public async Task HandleAsync(Commands.Opinion.AddOpinion command)
        {
            await _opinionService.AddAsync(_mapper.Map<Commands.Opinion.AddOpinion, Opinion>(command));
        }
    }
}
