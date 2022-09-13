using System;
using System.Collections.Generic;
using System.Text;
using LogicaAplicacion.CasosUso.IPaises;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfaceRepositorio;

namespace LogicaAplicacion.CasosUso.Paises
{
    public class Create : ICreate
    {
        private IRepositoryCountry _repo;

        public Create(IRepositoryCountry repo)
        {
            _repo = repo;
        }

        public void CreateCountry(Country obj)
        {
            _repo.Add(obj);
        }
    }
}
