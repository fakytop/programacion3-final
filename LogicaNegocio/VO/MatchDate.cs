using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.VO
{
    public class MatchDate
    {
        public DateTime Value { get; private set; }
        public List<int> Horas = new List<int>{ 7, 10, 13, 16 };
        public MatchDate(DateTime value)
        {
            Value = value;
            Validate();
        }

        public void Validate()
        {
            DateTime comienzo = new DateTime(2022, 11, 20);
            DateTime final = new DateTime(2022, 12, 2);

            if(Value < comienzo || Value > final)
            {
                throw new DomainException("DateTime is wrong.");
            }
            if (!Horas.Contains(Value.Hour) || Value.Minute != 0 || Value.Second != 0)
            {
                throw new DomainException("Time isn't valid.");
            }
        }
    }
}
