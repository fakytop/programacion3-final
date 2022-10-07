using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class GroupStageController : Controller
    {
        private IRead<GroupStage> _ucReadGroupStage;
        private IRead<NationalTeam> _ucReadNationalTeam;
        private IAssign<GroupStage> _ucAssign;

        public GroupStageController (IRead<GroupStage> ucReadGroupStage, IRead<NationalTeam> ucReadNationalTeam, IAssign<GroupStage> ucAssign)
        {
            _ucReadGroupStage = ucReadGroupStage;
            _ucReadNationalTeam = ucReadNationalTeam;
            _ucAssign = ucAssign;
        }
        [HttpGet]
        public IActionResult Assign()
        {
            ViewBag.NationalTeams = _ucReadNationalTeam.ReadAll();
            return View(_ucReadGroupStage.ReadAll ());
        }
        [HttpPost]
        public IActionResult Assign (int groupID, int nationalTeamID)
        {
            GroupStage group = _ucReadGroupStage.FindById(groupID);
            NationalTeam national = _ucReadNationalTeam.FindById(nationalTeamID);
            _ucAssign.AssignNationalTeam(group, national);
            return RedirectToAction("Index", "Home");
        }
    }
}
