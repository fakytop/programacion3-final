using System;
using System.Collections.Generic;
using System.Text;
using LogicaAccesoDatos.InterfaceRepositorio;
using LogicaNegocio.Entidades;

namespace LogicaAccesoDatos.Memoria
{
    public class RepositorioSeleccionNacional : IRepositoryNationalTeam
    {
        private static List<NationalTeam> selecciones = new List<NationalTeam>();


        public void Add(NationalTeam obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NationalTeam> All()
        {
            throw new NotImplementedException();
        }

        public void Update(NationalTeam obj)
        {
            throw new NotImplementedException();
        }
    }
}
