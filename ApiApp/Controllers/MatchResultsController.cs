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
    public class MatchResultsController : ControllerBase
    {
        private ICreate<MatchResult> _ucCreateMatchResult;
        private IRead<Match> _ucReadMatch;

        public MatchResultsController(
                ICreate<MatchResult> ucCreateMatchResult,
                IRead<GroupStage> ucReadGroupStage,
                IRead<Match> ucReadMatch
            )
        {
            _ucCreateMatchResult = ucCreateMatchResult;
            _ucReadMatch = ucReadMatch;
        }

        [HttpPost] 
        public IActionResult Create(MatchResultDto mrDto)
        {
            if(mrDto == null)
            {
                return BadRequest("Server dd not receive any data.");
            }

            try
            {
                MatchResult mr = MatchResultMapper.ToMatchResult(mrDto);
                mr.Match = _ucReadMatch.FindById(mrDto.MatchId);
                _ucCreateMatchResult.Create(mr);

                return Ok(mrDto);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception)
            {
                return StatusCode(500, "Something went wrong, please try again later");
            }
        } 
    }
}
