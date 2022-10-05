using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.Interfaces
{
    public interface IAssign<T>
    {
        public void AssignNationalTeam(GroupStage groupStage, NationalTeam nationalTeam);
    }
}
