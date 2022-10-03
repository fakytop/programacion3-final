using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.UCEntities.GroupsStage
{
    public class DeleteGroupStage: IDelete<GroupStage>
    {
        private IRepositoryGroupStage _repo;

        public DeleteGroupStage()
        {
        }

        public DeleteGroupStage(IRepositoryGroupStage repo)
        {
            _repo = repo;
        }

        public void Delete(GroupStage obj)
        {
            _repo.Delete(obj.Id);
        }

    }
}
