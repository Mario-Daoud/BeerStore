using AutoMapper;
using BeerStore.Areas.Admin.ViewModels;
using BeerStore.Service;
using BeerStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data;
using BeerStore.Models.Entities;

namespace BeerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BeerController : Controller
    {
        private readonly BeerService _beerService;
        private readonly BreweryService _breweryService;
        private readonly VarietyService _varietyService;
        private readonly IMapper _mapper;

        public BeerController(IMapper mapper)
        {
            _beerService = new BeerService();
            _breweryService = new BreweryService();
            _varietyService = new VarietyService();
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var lstBeers = await _beerService.GetAll();
                List<BeerAdminVM> beerVMs = new List<BeerAdminVM>();

                if (lstBeers != null)
                {
                    beerVMs = _mapper.Map<List<BeerAdminVM>>(lstBeers);
                }
                return View(beerVMs);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("errorlog {0}", ex.Message);
            }
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var beerCreate = new BeerCreateVM()
            {
                Breweries = new SelectList(await _breweryService.GetAll(), "Brouwernr", "Naam"),
                Soort = new SelectList(await _varietyService.GetAll(), "Soortnr", "Soortnaam")
            };


            return View(beerCreate);
        }

        // save to db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeerCreateVM entityVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var beer = _mapper.Map<Beer>(entityVM);
                    await _beerService.Insert(beer);
                    return RedirectToAction("Index");
                }
            }
            catch (SqlException ex)
            {
                ModelState.AddModelError("", "");
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Call system administration.");
            }

            // if failed => (+ keep track of selected item)
            entityVM.Breweries = new SelectList(await _breweryService.GetAll(),"Brouwernr", "Naam", entityVM.Brouwernr);
            entityVM.Soort = new SelectList(await _breweryService.GetAll(), "Soortnr", "Soortnaam", entityVM.Brouwernr);

            return View(entityVM);
        }


    }
}



