using LogicaAccesoDatos.EF;
using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.UCEntities.Matches
{
    public class ReadMatch : IRead<Match>
    {
        private IRepositoryMatch _db;

        public ReadMatch(IRepositoryMatch db)
        {
            _db = db;
        }

        public Match FindById(int id)
        {
            return _db.FindById(id);
        }

        public IEnumerable<Match> ReadAll()
        {
            throw new NotImplementedException();
        }
    }
}
