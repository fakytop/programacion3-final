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
    public class NationalTeamsController : ControllerBase
    {
        private ICreate<NationalTeam> _ucCreateNationalTeam;
        private IRead<NationalTeam> _ucReadNationalTeam;
        private IUpdate<NationalTeam> _ucUpdateNationalTeam;
        private IDelete<NationalTeam> _ucDeleteNationalTeam;
        private IRead<Country> _ucCountry;

        public NationalTeamsController(
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

        public IActionResult GetAll()
        {
            return Ok(NationalTeamMapper.FromNationalTeams(_ucReadNationalTeam.ReadAll()));
        }

        [HttpGet("{Id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(NationalTeamMapper.FromNationalTeam(_ucReadNationalTeam.FindById(id)));
            }
            catch (DomainException de)
            {
                return BadRequest(de.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Hubo un error, intente en unos minutos.");
            }
        }

        [HttpPost]
        public IActionResult Create(NationalTeamDto ntDto)
        {
            try
            {
                if(ntDto == null)
                {
                    return BadRequest("Los datos no fueron enviados.");
                }
                NationalTeam nationalTeam = NationalTeamMapper.ToNationalTeam(ntDto);
                nationalTeam.Country = _ucCountry.FindById(ntDto.idCountry);
                _ucCreateNationalTeam.Create(nationalTeam);

                return Ok(ntDto);
            }
            catch (DomainException de)
            {
                return BadRequest($"{de.Message}");
            }
            catch (Exception)
            {
                return StatusCode(500, "Hubo un error. Intente nuevamente en unos minutos.");
            }
        }
        [HttpPut]
        public IActionResult Edit(NationalTeamDto ntDto)
        {
            if (ntDto == null)
            {
                return BadRequest("Los datos no fueron enviados.");
            }
            try
            {
                NationalTeam nt = NationalTeamMapper.ToNationalTeam(ntDto);
                nt.Country = _ucCountry.FindById(ntDto.idCountry);
                _ucUpdateNationalTeam.Update(nt);
                return Ok(ntDto);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception)
            {
                return StatusCode(500, "Oops, something was wrong, try again later.");
            }
        }
        [HttpDelete("{Id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ucDeleteNationalTeam.Delete(new NationalTeam() { Id = id });
                return Ok("The National Team was deleted.");
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Oops, something was wrong, try again later.");
            }
        }

    }
}
