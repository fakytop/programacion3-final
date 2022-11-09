using ApiApp.Mapper;
using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Hosting;
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
    public class CountriesController : ControllerBase
    {
        private IRead<Country> _ucReadCountry;

        private IWebHostEnvironment _environment;

        public CountriesController(
            IRead<Country> ucReadCountries,
            IWebHostEnvironment environment
            )
        {
            _ucReadCountry = ucReadCountries;
            _environment = environment;
        }
        public IActionResult GetAll()
        {
            return Ok(CountryMapper.FromCountries(_ucReadCountry.ReadAll()));
        }

    }
}
