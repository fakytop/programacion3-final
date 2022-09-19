using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.UseCases.Countries
{
    public interface IUC_Country
    {
        public void Create(Country country);
        public IEnumerable<Country> All();
        public Country FindBy(int id);
        public Country FindBy(string isoalpha);
    }
}
