using System;
using System.Collections.Generic;
using LogicaNegocio.Entidades;
using System.Text;

namespace LogicaNegocio.Interfaces
{
    public interface IRepositoryNationalTeam: IRepository<NationalTeam>
    {
        public NationalTeam FindById(int id);
    }
}
