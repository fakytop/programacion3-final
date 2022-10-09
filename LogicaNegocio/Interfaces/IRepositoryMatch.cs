using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Entidades;


namespace LogicaNegocio.Interfaces
{
    public interface IRepositoryMatch: IRepository<Match>
    {
        public Match FindById(int id);
    }
}
