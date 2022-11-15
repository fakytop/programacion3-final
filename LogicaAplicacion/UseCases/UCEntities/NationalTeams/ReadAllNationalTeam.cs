using LogicaAplicacion.UseCases.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.UCEntities.NationalTeams
{
    public class ReadAllNationalTeam : IRead<NationalTeam>, IReadFilterNationalTeams<NationalTeam>
    {
        private IRepositoryNationalTeam _repo;

        public ReadAllNationalTeam(IRepositoryNationalTeam repo)
        {
            _repo = repo;
        }

        public NationalTeam FindById(int id)
        {
            return _repo.FindById(id);
        }

        public IEnumerable<NationalTeam> NationalTeamsByGroup(string groupName)
        {
            return _repo.NationalTeamsByGroup(groupName);
        }

        public IEnumerable<NationalTeam> ReadAll()
        {
            return _repo.All();
        }
    }
}
