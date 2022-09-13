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
        public IActionResult CreateCountry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCountry(Country letC, string Nombre, string IsoAlfa3, float PBI, int Poblacion, string Region)
        {
            ViewBag.Mensaje = "";
            try
            {
                letC.Name = new NameValue(Nombre);
                letC.IsoAlfa3 = new ISOAlfa3Value(IsoAlfa3);
                letC.GDP = new PositiveFloatValue (PBI);
                letC.Population = new PositiveIntegerValue(Poblacion);
                letC.Region = new RegionValue(Region);
                _ucCreate.CreateCountry(letC);
                return View();

            }
            catch (DomainException e)
            {
                ViewBag.Mensaje = e.Message;
            }

            return View(letC);
        }

    }
}
