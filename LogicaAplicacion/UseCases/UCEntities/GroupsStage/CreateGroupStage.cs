using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.UCEntities.GroupsStage
{
    public class CreateGroupStage : ICreate<GroupStage>
    {
        private IRepositoryGroupStage _repo;

        public CreateGroupStage(IRepositoryGroupStage repo)
        {
            _repo = repo;
        }

        public void Create(GroupStage obj)
        {
            _repo.Add(obj);
        }
    }
}