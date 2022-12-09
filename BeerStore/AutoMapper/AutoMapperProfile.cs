using AutoMapper;
using BeerStore.Models.Entities;
using BeerStore.ViewModels;

namespace BeerStore.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Beer, BeerVM>()
                .ForMember(dest => dest.BrouwerNaam, opts => opts.MapFrom(src => src.BrouwernrNavigation.Naam))
                .ForMember(dest => dest.SoortNaam, opts => opts.MapFrom(src => src.SoortnrNavigation.Soortnaam));

            CreateMap<Brewery, BreweryVM>();
        }
    }
}