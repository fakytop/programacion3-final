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
        private static int ultId = 1;

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
