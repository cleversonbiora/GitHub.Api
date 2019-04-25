using AutoMapper;
using GitHub.Domain.Models;
using GitHub.Domain.ViewModel;

namespace GitHub.Domain.AutoMapper
{
    class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Sample, SampleViewModel>();
        }
    }
}
