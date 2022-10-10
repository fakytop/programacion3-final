using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.Interfaces
{
    public interface IReadFilterCountry <Country>
    {
        public Country FindByISO(string iso);
        public IEnumerable<Country> FindByRegion(string region);
    }
}
