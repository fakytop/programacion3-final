using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.NationalTeams
{
    public class CreateNationalTeam : ICreate<NationalTeam>
    {
        private IRepositoryNationalTeam _repo;

        public CreateNationalTeam(IRepositoryNationalTeam repo)
        {
            _repo = repo;
        }

        public void Create(NationalTeam obj)
        {
            _repo.Add(obj);
        }
    }
}
