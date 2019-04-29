

using AutoMapper;
using GitHub.Domain.Commands.Sample;
using GitHub.Domain.Models;

namespace GitHub.Domain.AutoMapper
{
    class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<InsertSampleCommand, Repository>();
        }
    }
}
