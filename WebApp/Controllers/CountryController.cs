using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaAplicacion.UseCases.Countries;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using LogicaNegocio.Excepciones;

namespace WebApp.Controllers
{
    public class CountryController : Controller
    {
        private IUC_Country _use_cases;

        public CountryController(IUC_Country use_cases)
        {
            _use_cases = use_cases;
        }
        public IActionResult Index ()
        {
            return View(_use_cases.All());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Country country, string name, string isoalpha, float gdp, int population, string region)
        {
            ViewBag.Message = "";
            try
            {
                country.Name = new NameValue(name);
                country.IsoAlfa3 = new ISOAlfa3Value(isoalpha);
                country.GDP = new PositiveFloatValue (gdp);
                country.Population = new PositiveIntegerValue(population);
                country.Region = new RegionValue(region);
                _use_cases.Create(country);
                return View();

            }
            catch (DomainException e)
            {
                ViewBag.Message = e.Message;
            }

            return View(country);
        }

    }
}
