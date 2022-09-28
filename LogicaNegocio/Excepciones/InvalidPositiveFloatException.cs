using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class InvalidPositiveFloatException : DomainException
    {
        public InvalidPositiveFloatException(string message) : base(message)
        {

        }
    }
}
