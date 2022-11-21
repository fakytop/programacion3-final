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
                return StatusCode(500, "Something went wrong, please try again later.");
            }
        }

        [HttpPost]
        public IActionResult Create(NationalTeamDto ntDto)
        {
            try
            {
                if(ntDto == null)
                {
                    return BadRequest("Server did not receive any data.");
                }
                NationalTeam nationalTeam = NationalTeamMapper.ToNationalTeam(ntDto);
                nationalTeam.Country = _ucCountry.FindById(ntDto.Country.Id);
                _ucCreateNationalTeam.Create(nationalTeam);

                ntDto.Country = CountryMapper.FromCountry(nationalTeam.Country);

                return Ok(ntDto);
            }
            catch (DomainException de)
            {
                return BadRequest($"{de.Message}");
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong, please try again later.");
            }
        }
        [HttpPut]
        public IActionResult Edit(NationalTeamDto ntDto)
        {
            if (ntDto == null)
            {
                return BadRequest("Server did not receive any data.");
            }
            try
            {
                NationalTeam nt = NationalTeamMapper.ToNationalTeam(ntDto);
                nt.Country = _ucCountry.FindById(ntDto.idCountry);
                _ucUpdateNationalTeam.Update(nt);

                ntDto.Country = CountryMapper.FromCountry(nt.Country);

                return Ok(ntDto);
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
        [HttpDelete("{Id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ucDeleteNationalTeam.Delete(new NationalTeam() { Id = id });
                return Ok("success.");
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

    }
}
