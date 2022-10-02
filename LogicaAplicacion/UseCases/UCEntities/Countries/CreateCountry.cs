using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Interfaces;
using LogicaNegocio.Entidades;
using LogicaAplicacion.UseCases.Interfaces;

namespace LogicaAplicacion.UseCases.UCEntities.Countries
{
    public class CreateCountry : ICreate <Country>
    {
        private IRepositoryCountry _repository;

        public CreateCountry (IRepositoryCountry repository)
        {
            _repository = repository;
        }

        public void Create(Country country)
        {
            _repository.Add(country);
        }
    }
}
