using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class InvalidPositiveIntegerException : DomainException
    {
        public InvalidPositiveIntegerException(string message) : base(message)
        {

        }
    }
}
