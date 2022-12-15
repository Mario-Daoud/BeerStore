using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeerStore.ViewModels
{
    public class BreweryBeersVM
    {
        public int? BreweryNumber { get; set; }
        public IEnumerable<SelectListItem>? Breweries { get; set; }
        public IEnumerable<BeerVM>? Beers { get; set; }
    }
}
