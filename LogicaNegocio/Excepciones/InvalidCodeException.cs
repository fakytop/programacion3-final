using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class InvalidCodeException : DomainException
    {
        public InvalidCodeException (string message) : base (message)
        {

        }
    }
}
