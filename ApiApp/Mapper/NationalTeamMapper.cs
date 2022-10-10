using ApiApp.Dto;
using LogicaAplicacion.UseCases.UCEntities.Countries;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiApp.Mapper
{
    public static class NationalTeamMapper
    {
        public static NationalTeam ToNationalTeam(NationalTeamDto ntDto)
        {
            if(ntDto == null)
            {
                return null;
            }

            

            return new NationalTeam
            {
                Id = ntDto.Id,
                Name = new NameValue(ntDto.Name),
                Phone = new PhoneNumber(ntDto.Phone),
                Email = new EmailValue(ntDto.Email),
                Bettors = new PositiveIntegerValue(ntDto.Bettors)
            };
        }

        public static NationalTeamDto FromNationalTeam(NationalTeam nt)
        {
            if(nt == null)
            {
                return null;
            }
            return new NationalTeamDto
            {
                Id = nt.Id,
                idCountry = nt.Country.Id,
                Name = nt.Name.Value,
                Phone = nt.Phone.Value,
                Email = nt.Email.Value,
                Bettors = nt.Bettors.Value,
                GroupId = nt.GroupStageId
                
            };
        }

        public static IEnumerable<NationalTeamDto> FromNationalTeams(IEnumerable<NationalTeam> nts)
        {
            if(nts == null)
            {
                return null;
            }

            return nts.Select(nt => FromNationalTeam(nt));
        }
    }
}
