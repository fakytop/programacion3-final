using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Mapper;

namespace WebApp.Controllers
{
    public class NationalTeamController : Controller
    {
        private ICreate<NationalTeam> _ucCreateNationalTeam;
        private IRead<NationalTeam> _ucReadNationalTeam;
        private IUpdate<NationalTeam> _ucUpdateNationalTeam;
        private IDelete<NationalTeam> _ucDeleteNationalTeam;

        public NationalTeamController(
            ICreate<NationalTeam> createNT,
            IRead<NationalTeam> readNT,
            IUpdate<NationalTeam> updateNT,
            IDelete<NationalTeam> deleteNT
            )
        {
            _ucCreateNationalTeam = createNT;
            _ucReadNationalTeam = readNT;
            _ucUpdateNationalTeam = updateNT;
            _ucDeleteNationalTeam = deleteNT;
        }


        // GET: NationalTeamController
        public ActionResult Index()
        {
            return View(NationalTeamMapper.FromNationalTeams(_ucReadNationalTeam.ReadAll()));
            //Podría pasarle el listado de Countries para poder leer el pais en concreto.
        }

        // GET: NationalTeamController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NationalTeamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NationalTeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NationalTeamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NationalTeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NationalTeamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NationalTeamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
