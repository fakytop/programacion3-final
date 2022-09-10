using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfaceRepositorio;
using LogicaNegocio.Entidades;

namespace LogicaAccesoDatos.Memoria
{
    public class RepositorioSeleccionNacional : IRepositorioSeleccionNacional
    {
        private static List<SeleccionNacional> selecciones = new List<SeleccionNacional>();


        public void Add(SeleccionNacional obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SeleccionNacional> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(SeleccionNacional obj)
        {
            throw new NotImplementedException();
        }
    }
}
