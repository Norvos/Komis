using AutoMapper;
using Komis.Core.Models;
using Komis.Infrastructure.Commands.Opinion;

namespace Komis.Infrastructure.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddOpinion, Opinion>();
            })
            .CreateMapper();
    }
}
