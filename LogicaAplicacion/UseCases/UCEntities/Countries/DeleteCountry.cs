using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.UCEntities.Countries
{
    public class DeleteCountry : IDelete <Country>
    {
        IRepositoryCountry _repository;

        public DeleteCountry (IRepositoryCountry repository)
        {
            _repository = repository;
        }

        public void Delete (Country country)
        {
            _repository.Delete(country.Id);
        }
    }
}
