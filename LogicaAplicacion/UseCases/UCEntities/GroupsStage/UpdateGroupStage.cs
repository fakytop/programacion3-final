using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
namespace LogicaAplicacion.UseCases.UCEntities.GroupsStage
{
    class UpdateGroupStage: IUpdate<GroupStage>
    {
        private IRepositoryGroupStage _repo;

        public UpdateGroupStage(IRepositoryGroupStage repo)
        {
            _repo = repo;
        }

        public void Update(GroupStage obj)
        {
            _repo.Update(obj);
        }
    }
}
