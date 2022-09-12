using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Entidades
{
    public class GroupStage: IEntity
    {
        public int Id { get; set; }
        public CodeValue Group { get; set; }
        public List<NationalTeam> NationalTeams { get; set; }
    }
}
