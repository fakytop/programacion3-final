using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
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
        private IReadFilterCountry<Country> _ucReadFilterCountry;
        private IUpdate<Country> _ucUpdateCountry;
        private IDelete<Country> _ucDeleteCountry;

        private IWebHostEnvironment _environment;

        public CountryController(ICreate<Country> ucCreateCountry,
            IRead<Country> ucReadCountries,
            IReadFilterCountry<Country> ucReadFilterCountry, 
            IDelete<Country> ucDeleteCountry,
            IUpdate<Country> ucUpdateCountry,
            IWebHostEnvironment environment)
        {
            _ucCreateCountry = ucCreateCountry;
            _ucReadCountry = ucReadCountries;
            _ucReadFilterCountry = ucReadFilterCountry;
            _ucUpdateCountry = ucUpdateCountry;
            _ucDeleteCountry = ucDeleteCountry;
            _environment = environment;
        }
        public IActionResult Index ()
        {
            return View(_ucReadCountry.ReadAll());
        }
        [HttpPost]
        public IActionResult Index (string region)
        {
            ViewBag.Message = "";
            try
            {
                return View(_ucReadFilterCountry.FindByRegion(region));
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View(_ucReadCountry.ReadAll());
            } 
        }
        [HttpPost]
        public IActionResult FindByISO (string iso)
        {
            List<Country> countries = new List<Country>();
            try
            {
                countries.Add(_ucReadFilterCountry.FindByISO(iso));
                return View("Index", countries);
            } catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View("Index", _ucReadCountry.ReadAll());
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Country country, string name, string isoalpha, float gdp, int population, string region, IFormFile image)
        {
            ViewBag.Message = "";
            Country c = country;
            try
            {
                country.Name = new NameValue(name);
                country.IsoAlfa3 = new ISOAlfa3Value(isoalpha);
                country.GDP = new PositiveFloatValue (gdp);
                country.Population = new PositiveIntegerValue(population);
                country.Region = new RegionValue(region);
                country.Image = isoalpha + ".png";
                SaveFile(country, image);
                _ucCreateCountry.Create(country);
                return RedirectToAction("Index");

            }
            catch (DomainException e)
            {
                ViewBag.Message = e.Message;
            }
            return View(c);
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            ViewBag.Message = "";
            Country country = _ucReadCountry.FindById(id);
            try
            {
                _ucDeleteCountry.Delete(country);
            } catch (DomainException de)
            {
                ViewBag.Message = de.Message;
            }
            return View("Index", _ucReadCountry.ReadAll());
        }

        [HttpGet]
        public IActionResult Update (int id)
        {
            Country country = _ucReadCountry.FindById(id);
            return View(country);
        }
        [HttpPost]
        public IActionResult Update (int Id, string Name, string IsoAlpha3, float GDP, int Population, string Region)
        {
            Country country = new Country (Name, IsoAlpha3, GDP, Population, Region);
            country.Id = Id;
            _ucUpdateCountry.Update(country);
            return RedirectToAction("Index");
        }

        public void SaveFile (Country country, IFormFile file)
        {
            string wwwrootPath = _environment.WebRootPath;
            string fileName = country.IsoAlfa3.Value + ".png";
            string filePath = Path.Combine(wwwrootPath, "img", "countries", fileName);
            try
            {
                using (FileStream f = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(f);
                }
                country.Image = fileName;
            } catch (Exception e)
            {
                throw new Exception("Something went wrong, please try again later.");
            }
        }
    }
}
