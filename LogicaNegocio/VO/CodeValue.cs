using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.VO
{
    public class CodeValue
    {
        public List<char> validCodes = new List <char> () {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'};
        public string Value { get; private set; }

        public CodeValue(string value)
        {
            Value = value;
            validate();
        }

        public void validate()
        {
            foreach (var c in Value)
            {
                if (!validCodes.Contains(c))
                {
                    throw new InvalidCodeException("Invalid code: value must be character between A and H.");
                }
            }
        }
    
    }
}
