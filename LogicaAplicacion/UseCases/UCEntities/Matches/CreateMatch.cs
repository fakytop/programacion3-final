using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.UCEntities.Matches
{
    public class CreateMatch : ICreate<Match>
    {
        public IRepositoryMatch _db;

        public CreateMatch(IRepositoryMatch db)
        {
            _db = db;
        }

        public void Create(Match obj)
        {
            _db.Add(obj);
        }
    }
}
