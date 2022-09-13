using System;
using System.Collections.Generic;
using System.Text;
using LogicaAplicacion.CasosUso.IPaises;
using LogicaNegocio.InterfaceRepositorio;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.CasosUso.Paises
{
    public class List : IList
    {
        private IRepositoryCountry _repository;
        public IEnumerable<Country> FindAll ()
        {
            return _repository.FindAll();
        }
    }
}
