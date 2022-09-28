using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.UCEntities.NationalTeams
{
    public class DeleteNationalTeam : IDelete<NationalTeam>
    {
        private IRepositoryNationalTeam _repo;

        public DeleteNationalTeam(IRepositoryNationalTeam repo)
        {
            _repo = repo;
        }

        public void Delete(NationalTeam obj)
        {
            _repo.Delete(obj.Id);
        }
    }
}
