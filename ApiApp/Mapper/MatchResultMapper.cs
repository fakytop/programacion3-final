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
            return new MatchResult
            {
                Id = mrDto.Id,
                GoalsH = new PositiveIntegerValue(mrDto.GoalsH),
                GoalsA = new PositiveIntegerValue(mrDto.GoalsA),
                YellowCardsH = new PositiveIntegerValue(mrDto.YellowCardsH),
                YellowCardsA = new PositiveIntegerValue(mrDto.YellowCardsA),
                RedCardsH = new PositiveIntegerValue(mrDto.RedCardsH),
                RedCardsA = new PositiveIntegerValue(mrDto.RedCardsA),
                DirectRedCardsH = new PositiveIntegerValue(mrDto.DirectRedCardsH),
                DirectRedCardsA = new PositiveIntegerValue(mrDto.DIrectRedCardsA)
            };
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
                DIrectRedCardsA = mr.DirectRedCardsA.Value
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
