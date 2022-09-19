using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class InvalidEmailException : DomainException
    {
        public InvalidEmailException (string message) : base (message)
        {

        }
    }
}
