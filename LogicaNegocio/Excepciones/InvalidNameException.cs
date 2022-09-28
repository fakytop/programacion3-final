using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class InvalidNameException : DomainException
    {
        public InvalidNameException(string message) : base(message)
        {

        }
    }
}
