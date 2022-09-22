using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.VO
{
    public class PositiveIntegerValue
    {
        public int Value { get; private set; }

        public PositiveIntegerValue (int value)
        {
            Value = value;
            validate();
        }
        public void validate ()
        {
            if (Value < 0)
            {
                throw new InvalidPositiveIntegerException("Invalid Integer: value must be a positive integer.");
            }
        }
    }
}
