using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class InvalidRegionException : DomainException
    {
        public InvalidRegionException(string message) : base(message)
        {

        }
    }
}
