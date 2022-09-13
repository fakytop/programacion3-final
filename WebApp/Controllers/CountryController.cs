using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaAplicacion.CasosUso.IPaises;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using LogicaNegocio.Excepciones;

namespace WebApp.Controllers
{
    public class CountryController : Controller
    {
        private ICreate _ucCreate;
        private IFind _UCAll;

        public CountryController(ICreate ucCreate, IFind ucAll)
        {
            _ucCreate = ucCreate;
            _UCAll = ucAll;
        }
        public IActionResult Index ()
        {
            return View(_UCAll.All());
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
                _ucCreate.CreateCountry(country);
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
