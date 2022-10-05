using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.UCEntities.GroupsStage
{
    public class ReadAllGroupStage: IRead<GroupStage>
    {
        private IRepositoryGroupStage _repo;

        public ReadAllGroupStage(IRepositoryGroupStage repo)
        {
            _repo = repo;
        }

        public GroupStage FindById(int id)
        {
            return _repo.FindById(id);
        }

        public IEnumerable<GroupStage> ReadAll()
        {
            return _repo.All();
        }
    }
}
