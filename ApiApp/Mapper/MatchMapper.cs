using ApiApp.Dto;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Mapper
{
    public class MatchMapper
    {
        public static Match ToMatch(MatchDto mDto)
        {
            if(mDto == null)
            {
                return null;
            }
            return new Match
            {
                Id = mDto.Id,
                HomeId = mDto.HomeId,
                AwayId = mDto.AwayId,
                MatchDate = new MatchDate(mDto.MatchDate)
            };
        }

        public static MatchDto FromMatch(Match m)
        {
            if(m == null)
            {
                return null;
            }

            Match mr = new Match
                {
                    HomeStatistics = new Result(
                        m.HomeStatistics.Goals,
                        m.HomeStatistics.YellowCards,
                        m.HomeStatistics.RedCards.Value,
                        m.HomeStatistics.DirectRedCards
                        ),
                    AwayStatistics = new Result(
                        m.AwayStatistics.Goals,
                        m.AwayStatistics.YellowCards,
                        m.AwayStatistics.RedCards,
                        m.AwayStatistics.DirectRedCards
                        )
                };

            return new MatchDto
            {
                Id = m.Id,
                HomeId = m.Home.Id,
                AwayId = m.Away.Id,
                MatchResultDto = MatchResultMapper.FromMatchResult(mr),
                MatchDate = m.MatchDate.Value
            };
        }

        public static IEnumerable<MatchDto> FromMatches(IEnumerable<Match> matches)
        {
            if(matches == null)
            {
                return null;
            }

            return matches.Select(m => FromMatch(m));
        }
    }
}
