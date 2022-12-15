using AutoMapper;
using BeerStore.Areas.Admin.ViewModels;
using BeerStore.Service;
using Microsoft.AspNetCore.Mvc;

namespace BeerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BeerController : Controller
    {
        private readonly BeerService _beerService;
        private readonly BreweryService _breweryService;
        private readonly IMapper _mapper;

        public BeerController(IMapper mapper)
        {
            _beerService = new BeerService();
            _breweryService = new BreweryService();
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var lstBeers = await _beerService.GetAll();
            List<BeerAdminVM> beerVMs = null;

            if (lstBeers != null)
            {
                beerVMs = _mapper.Map<List<BeerAdminVM>>(lstBeers);
            }

            return View(beerVMs);
        }
    }
}



