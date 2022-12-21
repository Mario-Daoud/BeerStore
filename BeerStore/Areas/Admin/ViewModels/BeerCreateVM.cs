using BeerStore.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace BeerStore.Areas.Admin.ViewModels
{
    public class BeerCreateVM
    {
        [Required]
        public string? Naam{ get; set; }
        [Required]
        [Display(Name = "Brouwer")]
        public int Brouwernr { get; set; }

        public IEnumerable<SelectListItem>? Breweries{ get; set; }
        [Display(Name = "Soort")]
        public int Soortnr { get; set; }
        public IEnumerable<SelectListItem>? Soort { get; set; }
        [Required]
        public int Alcohol { get; set; }
    }
}
