using AutoMapper;

namespace BeerStore.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Models.Entities.Beer, ViewModels.BeerVM>()
                .ForMember(dest => dest.BrouwerNaam, opts => opts.MapFrom(src => src.BrouwernrNavigation.Naam))
                .ForMember(dest => dest.SoortNaam, opts => opts.MapFrom(src => src.SoortnrNavigation.Soortnaam));
        }
    }
}
