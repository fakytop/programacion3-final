using LogicaAplicacion.UseCases.Interfaces;
using LogicaAplicacion.UseCases.UCEntities.Countries;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Mapper;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class NationalTeamController : Controller
    {
        private ICreate<NationalTeam> _ucCreateNationalTeam;
        private IRead<NationalTeam> _ucReadNationalTeam;
        private IUpdate<NationalTeam> _ucUpdateNationalTeam;
        private IDelete<NationalTeam> _ucDeleteNationalTeam;
        private IRead<Country> _ucCountry;

        public NationalTeamController(
            ICreate<NationalTeam> createNT,
            IRead<NationalTeam> readNT,
            IUpdate<NationalTeam> updateNT,
            IDelete<NationalTeam> deleteNT,
            IRead<Country> ucCountry
            )
        {
            _ucCreateNationalTeam = createNT;
            _ucReadNationalTeam = readNT;
            _ucUpdateNationalTeam = updateNT;
            _ucDeleteNationalTeam = deleteNT;
            _ucCountry = ucCountry;
        }


        // GET: NationalTeamController
        public IActionResult Index(int Id)
        {
            return View(NationalTeamMapper.FromNationalTeams(_ucReadNationalTeam.ReadAll()));
            //TODO: Cuando reciba un Id != 0, necesito devolver un IEnumerable con una sola NT, para listarlo sobre el listado.
            //TODO: Otra forma es usar el control Details, donde recibiría un NT, en vez del listado.
        }

        
        public IActionResult Create()
        {
            ViewBag.CountriesList = _ucCountry.ReadAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NationalTeamVM ntVM)
        {
            NationalTeam nationalTeam = NationalTeamMapper.ToNationalTeam(ntVM);
            nationalTeam.Country = _ucCountry.FindById(ntVM.idCountry);
            _ucCreateNationalTeam.Create(nationalTeam);   


            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            NationalTeam nt = _ucReadNationalTeam.FindById(id);
            NationalTeamVM ntVM = NationalTeamMapper.FromNationalTeam(nt);
            ntVM.idCountry = nt.Country.Id;

            ViewBag.NT = ntVM;
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NationalTeamVM ntVM)
        {
            try
            {
                NationalTeam nt = NationalTeamMapper.ToNationalTeam(ntVM);
                nt.Country = _ucCountry.FindById(ntVM.idCountry);
                _ucUpdateNationalTeam.Update(nt);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            _ucDeleteNationalTeam.Delete(new NationalTeam() { Id = id });
            return RedirectToAction("Index");
        }

        //// POST: NationalTeamController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
