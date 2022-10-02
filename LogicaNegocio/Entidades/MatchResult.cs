using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class MatchResult
    {
        public GroupStage Group { get; set; }
        public Match Match { get; set; }
        public PositiveIntegerValue GoalsH { get; set; }
        public PositiveIntegerValue GoalsA { get; set; }
        public PositiveIntegerValue YellowCardsH { get; set; }
        public PositiveIntegerValue YellowCardsA { get; set; }
        public PositiveIntegerValue RedCardsH { get; set; }
        public PositiveIntegerValue RedCardsA { get; set; }
        public PositiveIntegerValue DirectRedCardsH { get; set; }
        public PositiveIntegerValue DirectRedCardsA { get; set; }
    }
}

//Prueba 2 de github
