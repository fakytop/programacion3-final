using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfaceRepositorio;
using LogicaNegocio.Entidades;

namespace LogicaAccesoDatos.Memoria
{
    public class RepositorioPartido : IRepositoryMatch
    {
        private static List<Match> partidos = new List<Match>();
        private static int ultId = 1;

        public void Add(Match obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Match> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Match obj)
        {
            throw new NotImplementedException();
        }
    }
}
