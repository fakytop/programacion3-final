using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class MatchResult : IEntity
    {
        public int Id { get; set; }
        public GroupStage Group { get; set; }
        public Match Match { get; set; }
        public int MatchId { get; set; }
        public PositiveIntegerValue GoalsH { get; set; }
        public PositiveIntegerValue GoalsA { get; set; }
        public PositiveIntegerValue YellowCardsH { get; set; }
        public PositiveIntegerValue YellowCardsA { get; set; }
        public PositiveIntegerValue RedCardsH { get; set; }
        public PositiveIntegerValue RedCardsA { get; set; }
        public PositiveIntegerValue DirectRedCardsH { get; set; }
        public PositiveIntegerValue DirectRedCardsA { get; set; }
        public PositiveIntegerValue PointsHome { get; set; }
        public PositiveIntegerValue PointsAway { get; set; }

        public MatchResult()
        {

        }

        public MatchResult(
                PositiveIntegerValue goalsH,
                PositiveIntegerValue goalsA,
                PositiveIntegerValue yellowCardsH,
                PositiveIntegerValue yellowCardsA,
                PositiveIntegerValue redCardsH,
                PositiveIntegerValue redCardsA,
                PositiveIntegerValue directRedCardsH,
                PositiveIntegerValue directRedCardsA
            )
        {
            this.GoalsH = goalsH;
            this.GoalsA = goalsA;
            this.YellowCardsH = yellowCardsH;
            this.YellowCardsA = yellowCardsA;
            this.RedCardsH = redCardsH;
            this.RedCardsA = redCardsA;
            this.DirectRedCardsH = directRedCardsH;
            this.DirectRedCardsA = directRedCardsA;

            if(goalsH.Value == goalsA.Value)
            {
                this.PointsHome = new PositiveIntegerValue(1);
                this.PointsAway = new PositiveIntegerValue(1);
            } 
            else if(goalsH.Value > goalsA.Value)
            {
                this.PointsHome = new PositiveIntegerValue(3);
                this.PointsAway = new PositiveIntegerValue(0);
            }
            else
            {
                this.PointsHome = new PositiveIntegerValue(0);
                this.PointsAway = new PositiveIntegerValue(3);
            }
        }

        public void Validate()
        {
            //TODO:
        }
    }
}

//Prueba 2 de github
