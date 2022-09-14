using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.VO
{
    public class ISOAlfa3Value
    {
        public string Value { get; private set;}

        public ISOAlfa3Value(string value)
        {
            Value = value;
            validate();
        }
        public void validate ()
        {
            if (String.IsNullOrEmpty (Value))
            {
                throw new InvalidISOAlphaException("Invalid ISOAlpha code: value cannot be null nor empty");
            }
            if (Value.Length != 3)
            {
                throw new InvalidISOAlphaException("Invalid ISOAlpha code: value must be three characters long.");
            }
            foreach (var c in Value)
            {
                if (!Char.IsLetter(c))
                {
                    throw new InvalidISOAlphaException("Invalid ISOAlpha code: value must only contain three letters.");
                }
            }
        }
    }
}