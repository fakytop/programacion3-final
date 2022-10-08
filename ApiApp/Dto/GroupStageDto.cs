using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Dto
{
    public class GroupStageDto
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public IEnumerable<NationalTeam> NationalTeams { get; set; }

    }
}
