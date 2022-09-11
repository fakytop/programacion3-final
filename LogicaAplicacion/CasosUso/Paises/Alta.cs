using System;
using System.Collections.Generic;
using System.Text;
using LogicaAplicacion.CasosUso.IPaises;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfaceRepositorio;

namespace LogicaAplicacion.CasosUso.Paises
{
    public class Alta : IAlta
    {
        private IRepositorioPais _repo;

        public Alta(IRepositorioPais repo)
        {
            _repo = repo;
        }

        public void CrearPais(Country obj)
        {
            _repo.Add(obj);
        }
    }
}
