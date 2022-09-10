using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class DomainException : Exception
    {
        public DomainException(string mensaje) : base(mensaje)
        {

        }
    }
}
