using LogicaAplicacion.UseCases.UCEntities.Countries;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Mapper
{
    public static class NationalTeamMapper
    {
        public static NationalTeam ToNationalTeam(NationalTeamVM ntVM)
        {
            if(ntVM == null)
            {
                return null;
            }

            

            return new NationalTeam
            {
                Id = ntVM.Id,
                Name = new NameValue(ntVM.Name),
                Phone = new PhoneNumber(ntVM.Phone),
                Email = new EmailValue(ntVM.Email),
                Bettors = new PositiveIntegerValue(ntVM.Bettors)
            };
        }

        public static NationalTeamVM FromNationalTeam(NationalTeam nt)
        {
            if(nt == null)
            {
                return null;
            }
            return new NationalTeamVM
            {
                Id = nt.Id,
                idCountry = nt.Country.Id,
                Name = nt.Name.Value,
                Phone = nt.Phone.Value,
                Email = nt.Email.Value,
                Bettors = nt.Bettors.Value
            };
        }

        public static IEnumerable<NationalTeamVM> FromNationalTeams(IEnumerable<NationalTeam> nts)
        {
            if(nts == null)
            {
                return null;
            }

            return nts.Select(nt => FromNationalTeam(nt));
        }
    }
}
