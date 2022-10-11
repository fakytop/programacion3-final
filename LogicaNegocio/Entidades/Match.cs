using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class Match: IEntity, IValidate
    {
        public int Id { get; set; }
        public NationalTeam Home { get; set; }
        public int? HomeId { get; set; }
        public NationalTeam Away { get; set; }
        public int? AwayId { get; set; }
        public Result HomeStatistics { get; set; }
        public Result AwayStatistics { get; set; }
        public MatchDate MatchDate { get; set; }
        public GroupStage Group { get; set; }
        public int GroupID { get; set; }

        public Match()
        {

        }

        public Match(NationalTeam home, NationalTeam away, Result pHomeStatistics, Result pAwayStatistics, MatchDate matchDate, int homeId, int awayId)
        {
            this.Home = home;
            this.HomeId = homeId;
            this.Away = away;
            this.AwayId = awayId;
            this.HomeStatistics = pHomeStatistics;
            this.AwayStatistics = pAwayStatistics;
            this.MatchDate = matchDate;
        }

        public void Validate()
        {

        }
    }
}
