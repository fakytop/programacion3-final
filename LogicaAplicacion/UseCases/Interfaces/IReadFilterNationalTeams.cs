using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.Interfaces
{
    public interface IReadFilterNationalTeams<NationalTeam>
    {
        public IEnumerable<NationalTeam> NationalTeamsByGroup(string groupName);
    }
}
