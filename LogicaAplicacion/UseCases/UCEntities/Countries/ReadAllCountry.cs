using System;
using System.Collections.Generic;
using System.Text;
using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;

namespace LogicaAplicacion.UseCases.UCEntities.Countries
{
    public class ReadAllCountry : IRead <Country>
    {
        private IRepositoryCountry _repository;

        public ReadAllCountry (IRepositoryCountry repository)
        {
            _repository = repository;
        }
        public IEnumerable<Country> ReadAll()
        {
            return _repository.All();
        }
    }
}
