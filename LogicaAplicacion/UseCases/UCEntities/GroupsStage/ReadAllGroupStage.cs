using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.UCEntities.GroupsStage
{
    class ReadAllGroupStage: IRead<GroupStage>
    {
        private IRepositoryGroupStage _repo;

        public ReadAllGroupStage(IRepositoryGroupStage repo)
        {
            _repo = repo;
        }

        public GroupStage FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupStage> ReadAll()
        {
            return _repo.All();
        }
    }
}
