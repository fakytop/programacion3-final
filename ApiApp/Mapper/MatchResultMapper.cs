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
        public static MatchResult ToMatchResult(MatchResultDto mrDto)
        {
            if (mrDto == null)
            {
                return null;
            }

            MatchResult mr = new MatchResult(
                    new PositiveIntegerValue(mrDto.GoalsH),
                    new PositiveIntegerValue(mrDto.GoalsA),
                    new PositiveIntegerValue(mrDto.YellowCardsH),
                    new PositiveIntegerValue(mrDto.YellowCardsA),
                    new PositiveIntegerValue(mrDto.RedCardsH),
                    new PositiveIntegerValue(mrDto.RedCardsA),
                    new PositiveIntegerValue(mrDto.DirectRedCardsH),
                    new PositiveIntegerValue(mrDto.DirectRedCardsA)
                );
            return mr;
        }

        public static MatchResultDto FromMatchResult(MatchResult mr)
        {
            if (mr == null)
            {
                return null;
            }

            return new MatchResultDto
            {
                Id = mr.Id,
                GroupId = mr.Group.Id,
                MatchId = mr.Match.Id,
                GoalsH = mr.GoalsH.Value,
                GoalsA = mr.GoalsA.Value,
                YellowCardsH = mr.YellowCardsH.Value,
                YellowCardsA = mr.YellowCardsA.Value,
                RedCardsH = mr.RedCardsH.Value,
                RedCardsA = mr.RedCardsA.Value,
                DirectRedCardsH = mr.DirectRedCardsH.Value,
                DirectRedCardsA = mr.DirectRedCardsA.Value,
                PointsHome = mr.PointsHome.Value,
                PointsAway = mr.PointsAway.Value
            };
        }

        public static IEnumerable<MatchResultDto> FromMatchResults(IEnumerable<MatchResult> mrsDto)
        {
            if (mrsDto == null)
            {
                return null;
            }
            return mrsDto.Select(mr => FromMatchResult(mr));
        }
    }
}
