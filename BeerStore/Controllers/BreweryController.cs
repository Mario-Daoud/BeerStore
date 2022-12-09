using AutoMapper;
using BeerStore.Models.Entities;
using BeerStore.Service;
using BeerStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeerStore.Controllers
{
    public class BreweryController : Controller
    {
        private readonly BreweryService _brewerService;

        private readonly IMapper _mapper;

        public BreweryController(IMapper mapper)
        {// Later with DI
            _mapper = mapper;

            _brewerService = new BreweryService();
        }
        public async Task<IActionResult> Index()
        {
            var lstBrewers = await _brewerService.GetAll();  // Domain objects
            List<BreweryVM> brewerVMs = null;

            if (lstBrewers != null)
            {
                brewerVMs = _mapper.Map<List<BreweryVM>>(lstBrewers);
            }

            return View(brewerVMs);  // Always VM 
        }
    }
}