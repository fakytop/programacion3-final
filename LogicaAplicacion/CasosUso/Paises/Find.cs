using System;
using System.Collections.Generic;
using System.Text;
using LogicaAplicacion.CasosUso.IPaises;
using LogicaAccesoDatos.InterfaceRepositorio;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.CasosUso.Paises
{
    public class Find : IPaises.IFind
    {
        private IRepositoryCountry _repository;

        public Find (IRepositoryCountry repository)
        {
            _repository = repository;
        }
        public IEnumerable<Country> All ()
        {
            return _repository.All();
        }
    }
}
