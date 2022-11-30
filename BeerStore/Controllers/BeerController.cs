using BeerStore.Service;
using BeerStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeerStore.Controllers
{
    public class BeerController : Controller
    {
        private readonly BeerService _beerService;

        public BeerController()
        {
            _beerService = new BeerService();
        }


        //zonder automapper
        public IActionResult Index()
        {
            var lstBeers = _beerService.GetAll();
            List<BeerVM> beerVMs = new List<BeerVM>();

            if (lstBeers != null)
            {
                foreach (var beer in lstBeers)
                {
                    var beerVM = new BeerVM();
                    beerVM.Naam = beer.Naam;
                    beerVM.BrouwerNaam = beer.BrouwernrNavigation.Naam;
                    beerVM.SoortNaam = beer.SoortnrNavigation.Soortnaam;
                    beerVM.Alcohol = beer.Alcohol;
                    beerVM.Image = beer.Image;
                    beerVMs.Add(beerVM);
                }
            }

            return View(beerVMs); //always vm
        }
    }
}
