using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.UCEntities.NationalTeams
{
    public class UpdateNationalTeam: IUpdate<NationalTeam>
    {
        private IRepositoryNationalTeam _repo;

        public UpdateNationalTeam(IRepositoryNationalTeam repo)
        {
            _repo = repo;
        }

        public void Update(NationalTeam obj)
        {
            _repo.Update(obj);
        }
    }
}
