using System;
using System.Collections.Generic;
using System.Text;
using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;

namespace LogicaAplicacion.UseCases.UCEntities.Countries
{
    public class ReadAllCountry : IRead <Country>, IReadFilterCountry<Country>
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

        public Country FindById(int id)
        {
            return _repository.FindById(id);
        }
        public Country FindByISO (string iso)
        {
            return _repository.FindByISO(iso);
        }
        public IEnumerable<Country> FindByRegion (string region)
        {
            return _repository.FindByRegion(region);
        }
    }
}
