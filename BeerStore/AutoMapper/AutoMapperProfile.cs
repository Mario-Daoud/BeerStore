using AutoMapper;
using BeerStore.Areas.Admin.ViewModels;
using BeerStore.Models.Entities;
using BeerStore.ViewModels;

namespace BeerStore.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // beers
            CreateMap<Beer, BeerVM>()
                .ForMember(dest => dest.BrouwerNaam, opts => opts.MapFrom(src => src.BrouwernrNavigation.Naam))
                .ForMember(dest => dest.SoortNaam, opts => opts.MapFrom(src => src.SoortnrNavigation.Soortnaam));

            // brewery
            CreateMap<Brewery, BreweryVM>();

            //edit beer crud 
            CreateMap<Beer, BeerAdminVM>()
                .ForMember(dest => dest.BrouwerNaam, opts => opts.MapFrom(src => src.BrouwernrNavigation.Naam))
                .ForMember(dest => dest.SoortNaam, opts => opts.MapFrom(src => src.SoortnrNavigation.Soortnaam));
        }
    }
}