using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EF
{
    public class RepositoryMatchResult : IRepositoryMatchResult
    {
        public ObligatorioContext _db;

        public RepositoryMatchResult(ObligatorioContext db)
        {
            _db = db;
        }

        public void Add(MatchResult obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MatchResult> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MatchResult obj)
        {
            throw new NotImplementedException();
        }
    }
}
