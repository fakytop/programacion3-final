using ApiApp.Dto;
using LogicaNegocio.Entidades;
using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Mapper
{
    public class MatchResultMapper
    {
        public static Match ToMatchResult(MatchResultDto mrDto)
        {
            if (mrDto == null)
            {
                return null;
            }

            Match mr = new Match {

                HomeStatistics = new Result(
                    mrDto.GoalsH,
                    mrDto.YellowCardsH,
                    mrDto.RedCardsH,
                    mrDto.DirectRedCardsH
                    ),
                AwayStatistics =  new Result(
                    mrDto.GoalsA,
                    mrDto.YellowCardsA,
                    mrDto.RedCardsA,
                    mrDto.DirectRedCardsA
                    )
            };
            return mr;
        }

        public static MatchResultDto FromMatchResult(Match mr)
        {
            if (mr == null)
            {
                return null;
            }

            return new MatchResultDto
            {
                GoalsH = mr.HomeStatistics.Goals.Value,
                GoalsA = mr.AwayStatistics.Goals.Value,
                YellowCardsH = mr.HomeStatistics.YellowCards.Value,
                YellowCardsA = mr.AwayStatistics.YellowCards.Value,
                RedCardsH = mr.HomeStatistics.RedCards.Value,
                RedCardsA = mr.AwayStatistics.RedCards.Value,
                DirectRedCardsH = mr.HomeStatistics.DirectRedCards.Value,
                DirectRedCardsA = mr.AwayStatistics.DirectRedCards.Value
            };
        }
        //No sería necesario.
        public static IEnumerable<MatchResultDto> FromMatchResults(IEnumerable<Match> mrsDto)
        {
            if (mrsDto == null)
            {
                return null;
            }
            return mrsDto.Select(mr => FromMatchResult(mr));
        }
    }
}
