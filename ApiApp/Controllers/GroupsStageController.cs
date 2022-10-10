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
        private IUpdate<GroupStage> _ucUpdateGroupStage;
        private IDelete<GroupStage> _ucDeleteGroupStage;

        private IRead<NationalTeam> _ucReadNationalTeam;
        private IAssign<GroupStage> _ucAssign;

        public GroupsStageController(
            IRead<GroupStage> ucReadGroupStage,
            IRead<NationalTeam> ucReadNationalTeam,
            IAssign<GroupStage> ucAssign,
            ICreate<GroupStage> ucCreateGroupStage,
            IUpdate<GroupStage> ucUpdateGroupStage,
            IDelete<GroupStage> ucDeleteGroupStage
            )
        {
            _ucReadGroupStage = ucReadGroupStage;
            _ucReadNationalTeam = ucReadNationalTeam;
            _ucAssign = ucAssign;
            _ucCreateGroupStage = ucCreateGroupStage;
            _ucUpdateGroupStage = ucUpdateGroupStage;
            _ucDeleteGroupStage = ucDeleteGroupStage;
        }

        public IActionResult GetAll()
        {
            return Ok(GroupStageMapper.FromGroupsStage(_ucReadGroupStage.ReadAll()));
        }
        
        [HttpPost]
        public IActionResult Create(GroupStageDto gsDto)
        {
            try
            {
                if(gsDto == null)
                {
                    return BadRequest("Server did not receive any data.");
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
                return StatusCode(500, "Something went wrong, please try again later.");
            }
        }

        [HttpPut]
        public IActionResult Edit(GroupStageDto gsDto)
        {
            if(gsDto == null)
            {
                return BadRequest("Server did not receive any data.");
            }
            try
            {
                GroupStage group = _ucReadGroupStage.FindById(gsDto.Id);
                GroupStage gs = GroupStageMapper.ToGroupStage(gsDto);
                gs.NationalTeams = group.NationalTeams;

                _ucUpdateGroupStage.Update(gs);

                return Ok(GroupStageMapper.FromGroupStage(gs));
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong, please try again later.");
            }
        }

        [HttpDelete("{Id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ucDeleteGroupStage.Delete(new GroupStage() { Id = id });
                return Ok("Success.");
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong, please try again later.");
            }
        }

        [HttpPut]
        [Route("group/{groupID}/nationalteam/{nationalTeamID}")]
        public IActionResult Assign(int groupID, int nationalTeamID)
        {
            try
            {
                GroupStage group = _ucReadGroupStage.FindById(groupID);
                NationalTeam national = _ucReadNationalTeam.FindById(nationalTeamID);
                _ucAssign.AssignNationalTeam(group, national);

                return Ok("Success.");
            }
            catch(DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
