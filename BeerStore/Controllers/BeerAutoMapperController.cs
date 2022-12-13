using AutoMapper;
using BeerStore.Service;
using BeerStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeerStore.Controllers
{
    public class BeerAutoMapperController : Controller
    {
        private readonly BeerService _beerService;
        private readonly BreweryService _breweryService;
        private readonly IMapper _mapper;

        public BeerAutoMapperController(IMapper mapper)
        {
            _beerService = new BeerService();
            _breweryService = new BreweryService();
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var lstBeers = await _beerService.GetAll();
            List<BeerVM> beerVMs = null;

            if (lstBeers != null)
            {
                beerVMs = _mapper.Map<List<BeerVM>>(lstBeers);
            }

            return View(beerVMs);
        }

        public IActionResult IndexByAlcohol()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexByAlcohol(int? txtAlcohol)
        {

            if (txtAlcohol == null)
            {
                return IndexByAlcohol();
            }

            var lstBeers = await _beerService.GetBeersByAlcohol((decimal)txtAlcohol);

            List<BeerVM> beerVMs = null;

            if (lstBeers != null)
            {
                beerVMs = _mapper.Map<List<BeerVM>>(lstBeers);
            }
            return View(beerVMs);

        }

        public async Task<IActionResult> GetBrouwer()
        {
            ViewBag.lstBrouwer = new SelectList(await _breweryService.GetAll(), "Naam", "Naam");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetBrouwer(String brouwerId)
        {
            var lstBeer = await _beerService.GetBeerWithBrewer(brouwerId);

            ViewBag.lstBrouwer = new SelectList(await _breweryService.GetAll(), "Naam", "Naam");

            

            List<BeerVM> beerVMs = null;

            if (lstBeer != null)
            {
                beerVMs = _mapper.Map<List<BeerVM>>(lstBeer);
            }


            return View(beerVMs);
        }


    }
}
