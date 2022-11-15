using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.UseCases.Interfaces
{
    public interface IReadFilterMatches<Match>
    {
        public IEnumerable<Match> ReadMatchesByGroup(string groupName);
    }
}
