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

        public void Validate()
        {
            //TODO:
        }
    }
}

//Prueba 2 de github
