using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Interfaces;
using LogicaNegocio.Entidades;

namespace LogicaAccesoDatos.Memoria
{
    public class RepositorioPartido : IRepositoryMatch
    {
        private static List<Match> partidos = new List<Match>();
#pragma warning disable CS0414 // El campo 'RepositorioPartido.ultId' está asignado pero su valor nunca se usa
        private static int ultId = 1;
#pragma warning restore CS0414 // El campo 'RepositorioPartido.ultId' está asignado pero su valor nunca se usa

        public void Add(Match obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Match> All()
        {
            throw new NotImplementedException();
        }

        public void Update(Match obj)
        {
            throw new NotImplementedException();
        }

        public Match FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
