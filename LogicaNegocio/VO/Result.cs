using LogicaNegocio.Excepciones;
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
            Validate();
        }

        public void Validate()
        {
            if(Goals < 0)
            {
                throw new DomainException("Goals must be positive.");
            }
            if(YellowCards < 0)
            {
                throw new DomainException("Yellow Cards must be positive.");
            }
            if(RedCards < 0)
            {
                throw new DomainException("Red Cards must be positive.");
            }
            if(DirectRedCards < 0)
            {
                throw new DomainException("Direct Red Cards must be positive.");
            }
        }
    }
}
