using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.VO
{
    public class NameValue
    {
        public string Value { get; private set; }

        public NameValue(string value)
        {
            Value = value;
            validate();
        }
        public void validate ()
        {
            if (String.IsNullOrEmpty(Value))
            {
                throw new InvalidNameException("Invalid name: name must not be null or empty.");
            }
            if (String.IsNullOrWhiteSpace(Value))
            {
                throw new InvalidNameException("Invalid name: name must not consist only of white-space characters.");
            }
            foreach (var c in Value)
            {
                if (!Char.IsLetter(c))
                {
                    throw new InvalidNameException("Invalid name: name must only contain letters.");
                }
            }
        }
    }
}
