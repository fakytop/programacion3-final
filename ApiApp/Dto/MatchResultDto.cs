using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Dto
{
    public class MatchResultDto
    {
        public int? GoalsH { get; set; }
        public int? GoalsA { get; set; }
        public int? YellowCardsH { get; set; }
        public int? YellowCardsA { get; set; }
        public int? RedCardsH { get; set; }
        public int? RedCardsA { get; set; }
        public int? DirectRedCardsH { get; set; }
        public int? DirectRedCardsA { get; set; }

    }
}
