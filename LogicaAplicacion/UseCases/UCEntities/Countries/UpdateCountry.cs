using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.UCEntities.Countries
{
    public class UpdateCountry : IUpdate <Country>
    {
        private IRepositoryCountry _repository;
        public UpdateCountry(IRepositoryCountry repository)
        {
            _repository = repository;
        }
        public void Update (Country country)
        {
            _repository.Update(country);
        }
    }
}
