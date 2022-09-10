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
        public IActionResult CreatePais(Pais unPais, string Nombre, string IsoAlfa3, decimal PBI, int Poblacion, string Region)
        {
            ViewBag.Mensaje = "";

            try
            {

                unPais.Nombre = new Nombre(Nombre);
                unPais.IsoAlfa3 = new ISOAlfa3(IsoAlfa3);
                unPais.PBI = new PBI(PBI);
                unPais.Poblacion = new Poblacion(Poblacion);
                unPais.Region = new Region(Region);

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
