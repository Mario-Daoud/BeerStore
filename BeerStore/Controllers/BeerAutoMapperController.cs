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
            ViewBag.lstBrouwer = new SelectList(await _breweryService.GetAll(), "Brouwernr", "Naam");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetBrouwer(int? brouwerId)
        {

            if (brouwerId == null)
            {
                return NotFound();
            }

            var lstBeer = await _beerService.GetBeerWithBrewer(Convert.ToInt16(brouwerId));

            ViewBag.lstBrouwer = new SelectList(await _breweryService.GetAll(), "Brouwernr", "Naam");



            List<BeerVM> beerVMs = null;

            if (lstBeer != null)
            {
                beerVMs = _mapper.Map<List<BeerVM>>(lstBeer);
            }


            return View(beerVMs);
        }

        public async Task<IActionResult> GetBrouwerVM()
        {
            BreweryBeersVM breweryBeersVM = new BreweryBeersVM();

            breweryBeersVM.Breweries = new SelectList(await _breweryService.GetAll(), "Brouwernr", "Naam");

            return View(breweryBeersVM);
        }

        [HttpPost]
        public async Task<ActionResult> GetBrouwerVM(BreweryBeersVM entity)
        {

            if (entity.BreweryNumber == null)
            {
                return NotFound();
            }

            var bierList = await _beerService.GetBeerWithBrewer(Convert.ToInt16(entity.BreweryNumber));

            BreweryBeersVM brouwersBierenVM = new BreweryBeersVM();
            brouwersBierenVM.Beers = _mapper.Map<List<BeerVM>>(bierList);

            brouwersBierenVM.Breweries = new SelectList(await _breweryService.GetAll(),
                 "Brouwernr", "Naam", entity.BreweryNumber);


            return View(brouwersBierenVM);

        }

        public async Task<IActionResult> GetBrouwerAjax()
        {
            BreweryBeersVM breweryBeersVM = new BreweryBeersVM();

            breweryBeersVM.Breweries = new SelectList(await _breweryService.GetAll(), "Brouwernr", "Naam");

            return View(breweryBeersVM);
        }

        [HttpPost]
        public async Task<IActionResult> GetBrouwerAjax(BreweryBeersVM entity)
        {
            if (entity.BreweryNumber == null)
            {
                return NotFound();
            }

            var bierList = await _beerService.GetBeerWithBrewer(Convert.ToInt16(entity.BreweryNumber));
            List<BeerVM> listVM = _mapper.Map<List<BeerVM>>(bierList);

            // manual wachttijd zodat je spinner ziet
            Thread.Sleep(1000); // ------ mag je natuurlijk weglaten, hier wordt 2 sec. gewacht
            return PartialView("_SearchBierenPartial", listVM);

        }

    }
}
