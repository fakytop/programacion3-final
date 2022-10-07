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

        public void Validate()
        {
            //validar todo 
        }

        public void AddNationalTeam (NationalTeam nationalTeam)
        {
            
            if (NationalTeams.Contains (nationalTeam))
            {
                 throw new Exception("No");
            }
            NationalTeams.Add(nationalTeam);
            Validate();
        }

        public void Update(GroupStage gs)
        {
            Group = gs.Group;
            NationalTeams = gs.NationalTeams;
        }
    }
}
