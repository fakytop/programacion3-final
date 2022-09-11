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
    public class PaisController : Controller
    {
        private IAlta _cuAlta;

        public PaisController(IAlta cuAlta)
        {
            this._cuAlta = cuAlta;
        }
        public IActionResult CreatePais()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePais(Country unPais, string Nombre, string IsoAlfa3, float PBI, int Poblacion, string Region)
        {
            ViewBag.Mensaje = "";
            try
            {
                unPais.Nombre = new NameValue(Nombre);
                unPais.IsoAlfa3 = new ISOAlfa3Value(IsoAlfa3);
                unPais.PBI = new PositiveFloatValue (PBI);
                unPais.Poblacion = new PositiveIntegerValue(Poblacion);
                unPais.Region = new RegionValue(Region);
                _cuAlta.CrearPais(unPais);
                return View();

            }
            catch (DomainException e)
            {
                ViewBag.Mensaje = e.Message;
            }

            return View(unPais);
        }

    }
}
