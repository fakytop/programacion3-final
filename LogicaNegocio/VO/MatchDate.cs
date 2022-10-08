using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.VO
{
    public class MatchDate
    {
        public DateTime Value { get; private set; }

        public MatchDate(DateTime value)
        {
            Value = value;
            Validate();
        }

        public void Validate()
        {
            //TODO: validar.
        }
    }
}
