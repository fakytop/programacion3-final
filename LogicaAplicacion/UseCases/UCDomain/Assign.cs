using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.UCDomain
{
    public class Assign : IAssign<GroupStage>
    {
        private IRepositoryGroupStage _repository;

        public Assign (IRepositoryGroupStage repository)
        {
            _repository = repository;
        }
        public void AssignNationalTeam (GroupStage groupStage, NationalTeam nationalTeam)
        {
            try
            {
                groupStage.AddNationalTeam(nationalTeam);
                _repository.Update(groupStage);
            } catch (DomainException e)
            {
                throw new DomainException(e.Message);
            }
        }
    }
}
