using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Interfaces;
using LogicaNegocio.Entidades;

namespace LogicaAccesoDatos.Memoria
{
    public class RepositorioResultadoPartido : IRepositoryMatchResult
    {
        private static List<MatchResult> resultados = new List<MatchResult>();
#pragma warning disable CS0414 // El campo 'RepositorioResultadoPartido.ultId' está asignado pero su valor nunca se usa
        private static int ultId = 1;
#pragma warning restore CS0414 // El campo 'RepositorioResultadoPartido.ultId' está asignado pero su valor nunca se usa

        public void Add(MatchResult obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MatchResult> All()
        {
            throw new NotImplementedException();
        }

        public void Update(MatchResult obj)
        {
            throw new NotImplementedException();
        }
    }
}
