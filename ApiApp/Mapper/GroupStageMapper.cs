using ApiApp.Dto;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Mapper
{
    public static class GroupStageMapper
    {
        public static GroupStage ToGroupStage(GroupStageDto gsDto)
        {
            if(gsDto == null)
            {
                return null;
            }
            return new GroupStage
            {
                Id = gsDto.Id,
                Group = new CodeValue(gsDto.Group)
            };
        } 
        
        public static GroupStageDto FromGroupStage(GroupStage gs)
        {
            if(gs == null)
            {
                return null;
            }

            return new GroupStageDto
            {
                Id = gs.Id,
                Group = gs.Group.Value,
                NationalTeams = gs.NationalTeams
            
            };
        }

        public static IEnumerable<GroupStageDto> FromGroupsStage(IEnumerable<GroupStage> gss)
        {
            if(gss == null)
            {
                return null;
            }
            return gss.Select(gs => FromGroupStage(gs));
        }
    }
}
