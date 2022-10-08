using ApiApp.Dto;
using ApiApp.Mapper;
using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsStageController : ControllerBase
    {
        private IRead<GroupStage> _ucReadGroupStage;
        private ICreate<GroupStage> _ucCreateGroupStage;

        private IRead<NationalTeam> _ucReadNationalTeam;
        private IAssign<GroupStage> _ucAssign;

        public GroupsStageController(
            IRead<GroupStage> ucReadGroupStage,
            IRead<NationalTeam> ucReadNationalTeam,
            IAssign<GroupStage> ucAssign,
            ICreate<GroupStage> ucCreateGroupStage)
        {
            _ucReadGroupStage = ucReadGroupStage;
            _ucReadNationalTeam = ucReadNationalTeam;
            _ucAssign = ucAssign;
            _ucCreateGroupStage = ucCreateGroupStage;
        }

        public IActionResult GetAll()
        {
            //return Ok(_ucReadGroupStage.ReadAll());
            return Ok(GroupStageMapper.FromGroupsStage(_ucReadGroupStage.ReadAll()));
        }
        
        [HttpPost]
        public IActionResult Create(GroupStageDto gsDto)
        {
            try
            {
                if(gsDto == null)
                {
                    return BadRequest("Los datos no fueron enviados.");
                }

                GroupStage group = GroupStageMapper.ToGroupStage(gsDto);
                _ucCreateGroupStage.Create(group);

                return Ok(gsDto);

            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception)
            {
                return StatusCode(500, "Something was wrong, try again later.");
            }
        }

    }
}
