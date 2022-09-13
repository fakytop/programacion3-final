using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.VO
{
    public class PhoneNumber
    {
        public string Value { get; private set; }

        public PhoneNumber()
        {
            Value = "Innominated";
        }

        public PhoneNumber(string phone)
        {
            Validate(phone);
            Value = phone;

        }

        public void Validate(string phone)
        {
            if (String.IsNullOrEmpty(phone))
            {
                throw new InvalidPhoneException("Invalid phone number: Field can't be null");
            }
            if (phone.Length < 7)
            {
                throw new InvalidPhoneException("Invalid phone number: Must have at least 7 characters.");
            }
            foreach(var n in phone)
            {
                if (!Char.IsNumber(n))
                {
                    throw new InvalidPhoneException("Invalid phone number: The field must be completed with numbers.");
                }
            }
        }
    }
}
