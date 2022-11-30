using AutoMapper;
using BeerStore.Service;
using BeerStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeerStore.Controllers
{
    public class BeerAutoMapperController : Controller
    {
        private readonly BeerService _beerService;
        private readonly IMapper _mapper;

        public BeerAutoMapperController(IMapper mapper)
        {
            _beerService = new BeerService();
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var lstBeers = _beerService.GetAll();
            List<BeerVM> beerVMs = new List<BeerVM>();

            if (lstBeers != null)
            {
                beerVMs = _mapper.Map<List<BeerVM>>(lstBeers);
            }

            return View(beerVMs);
        }
    }
}
