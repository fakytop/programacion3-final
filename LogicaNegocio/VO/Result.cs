using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.VO
{
    public class Result
    {
        public int? Goals { get; set; }
        public int? YellowCards { get; set; }
        public int? RedCards { get; set; }
        public int? DirectRedCards { get; set; }

        public Result()
        {

        }

        public Result(int? pGoals, int? pYellowCards, int? pRedCards, int? pDirectRedCards)
        {
            Goals = pGoals;
            YellowCards = pYellowCards;
            RedCards = pRedCards;
            DirectRedCards = pDirectRedCards;
        }
    }
}
