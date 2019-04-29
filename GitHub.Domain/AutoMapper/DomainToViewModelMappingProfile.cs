using AutoMapper;
using GitHub.Domain.Models;
using GitHub.Domain.ViewModel;

namespace GitHub.Domain.AutoMapper
{
    class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Repository, RepositoryViewModel>();
            CreateMap<Owner, OwnerViewModel>();
            CreateMap<Repository, RepositoryResumeViewModel>()
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(x => x.Owner.Id))
                .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(x => x.Owner.AvatarUrl))
                .ForMember(dest => dest.OwnerHtmlUrl, opt => opt.MapFrom(x => x.Owner.HtmlUrl))
                .ForMember(dest => dest.ReposUrl, opt => opt.MapFrom(x => x.Owner.Url));
        }
    }
}
