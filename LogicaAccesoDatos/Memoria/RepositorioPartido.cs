using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfaceRepositorio;
using LogicaNegocio.Entidades;

namespace LogicaAccesoDatos.Memoria
{
    public class RepositorioPartido : IRepositorioPartido
    {
        private static List<Partido> partidos = new List<Partido>();
        private static int ultId = 1;

        public void Add(Partido obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Partido> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Partido obj)
        {
            throw new NotImplementedException();
        }
    }
}
