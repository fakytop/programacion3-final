using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.UCEntities.MatchResults
{
    public class CreateMatchResult : ICreate<MatchResult>
    {
        public IRepositoryMatchResult _db;

        public CreateMatchResult(IRepositoryMatchResult db)
        {
            _db = db;
        }

        public void Create(MatchResult obj)
        {
            _db.Add(obj);
        }
    }
}
