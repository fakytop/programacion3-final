using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Interfaces
{
    public interface IRepositoryGroupStage: IRepository<GroupStage>
    {
        public GroupStage FindById(int id);
    }
}
