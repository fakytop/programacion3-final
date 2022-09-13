using System;
using System.Collections.Generic;
using System.Text;
using LogicaAplicacion.CasosUso.IPaises;
using LogicaNegocio.Entidades;
using LogicaAccesoDatos.InterfaceRepositorio;

namespace LogicaAplicacion.CasosUso.Paises
{
    public class Create : ICreate
    {
        private IRepositoryCountry _repository;

        public Create(IRepositoryCountry repository)
        {
            _repository = repository;
        }

        public void CreateCountry(Country obj)
        {
            _repository.Add(obj);
        }
    }
}
