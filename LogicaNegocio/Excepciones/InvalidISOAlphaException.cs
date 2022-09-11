using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    class InvalidISOAlphaException : DomainException
    {
        public InvalidISOAlphaException(string message) : base(message)
        {

        }
    }
}
