using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.VO
{
    public class PositiveFloatValue
    {
        public float Value { get; private set; }

        public PositiveFloatValue (float value)
        {
            Value = value;
            validate();
        }
        public void validate ()
        {
            if (Value < 0)
            {
                throw new InvalidPositiveFloatException("Invalid float: value must be a positive number.");
            }
        }

    }
}
