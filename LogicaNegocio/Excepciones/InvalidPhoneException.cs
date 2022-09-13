using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class InvalidPhoneException: DomainException
    {
        public InvalidPhoneException(string message) : base(message)
        {

        }
    }
}
