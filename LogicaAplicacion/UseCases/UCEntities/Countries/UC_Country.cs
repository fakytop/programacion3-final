using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Interfaces;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.UseCases.UCEntities.Countries
{
    public class UC_Country : IUC_Country
    {
        private IRepositoryCountry _repository;

        public UC_Country(IRepositoryCountry repository)
        {
            _repository = repository;
        }
        public IEnumerable<Country> All()
        {
            return _repository.All();
        }
        public void Create(Country country)
        {
            _repository.Add(country);
        }

        public Country FindBy(int id)
        {
            throw new NotImplementedException();
        }

        public Country FindBy(string isoalpha)
        {
            throw new NotImplementedException();
        }
    }
}
