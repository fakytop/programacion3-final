using System;
using System.Collections.Generic;
using LogicaNegocio.Entidades;
using System.Text;

namespace LogicaNegocio.Interfaces
{
    public interface IRepositoryMatchResult: IRepository<MatchResult>
    {
        public MatchResult FindById(int id);
    }
}
