using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class Match: IEntity
    {
        public int Id { get; set; }
        public NationalTeam Home { get; set; }
        public int? HomeId { get; set; }
        public NationalTeam Away { get; set; }
        public int? AwayId { get; set; }
        public MatchResult MatchResult { get; set; }
        public int? MatchResultId { get; set; }
        public MatchDate MatchDate { get; set; }
        public GroupStage Group { get; set; }
        public int GroupID { get; set; }

        public Match()
        {

        }

        public Match(NationalTeam home, NationalTeam away, MatchResult matchResult, int MatchResultId, MatchDate matchDate, int homeId, int awayId)
        {
            this.Home = home;
            this.HomeId = homeId;
            this.Away = away;
            this.AwayId = awayId;
            this.MatchResult = matchResult;
            this.MatchResultId = MatchResultId;
            this.MatchDate = matchDate;
        }

        public void Validate()
        {

        }
    }
}
