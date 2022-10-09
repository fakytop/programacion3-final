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
        private IRepositoryMatch _repository;

        public ReadMatch(IRepositoryMatch repository)
        {
            _repository = repository;
        }

        public Match FindById(int id)
        {
            return _repository.FindById(id);
        }

        public IEnumerable<Match> ReadAll()
        {
            return _repository.All();
        }
    }
}
