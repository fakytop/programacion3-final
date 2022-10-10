using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Entidades
{
    public class GroupStage: IEntity, IValidate
    {
        public int Id { get; set; }
        public CodeValue Group { get; set; }
        public List<NationalTeam> NationalTeams { get; set; }

        public void Validate()
        {
            if(NationalTeams.Count >= 4)
            {
                throw new DomainException("Can't be added.");
            } 

        }

        public void AddNationalTeam (NationalTeam nationalTeam)
        {
            
            if (NationalTeams.Contains (nationalTeam))
            {
                 throw new DomainException("The National Team is already assigned.");
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
