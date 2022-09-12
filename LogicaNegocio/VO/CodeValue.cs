using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.VO
{
    public class CodeValue
    {
        public string Value { get; private set; }

        public CodeValue(string cod)
        {
            Validate(cod);
            Value = cod;
        }

        public void Validate(string cod)
        {
            //TODO: Validar grupo.
        }
    
    }
}
