using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaAplicacion.UseCases.UCEntities.Countries;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using LogicaNegocio.Excepciones;
using LogicaAplicacion.UseCases.Interfaces;

namespace WebApp.Controllers
{
    public class CountryController : Controller
    {
        private ICreate<Country> _ucCreateCountry;
        private IRead<Country> _ucReadCountry;
        private IDelete<Country> _ucDeleteCountry;

        public CountryController(ICreate<Country> ucCreateCountry, IRead<Country> ucReadCountries, IDelete<Country> ucDeleteCountry)
        {
            _ucCreateCountry = ucCreateCountry;
            _ucReadCountry = ucReadCountries;
            _ucDeleteCountry = ucDeleteCountry;
        }
        public IActionResult Index ()
        {
            return View(_ucReadCountry.ReadAll());
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
                _ucCreateCountry.Create(country);
                return View();

            }
            catch (DomainException e)
            {
                ViewBag.Message = e.Message;
            }

            return View(country);
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            Country country = _ucReadCountry.FindById(id);
            _ucDeleteCountry.Delete(country);
            return RedirectToAction("Index");
        }
    }
}
