using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.VO
{
    public class Contact
    {
        private NameValue name;
        private EmailValue email;
        private PhoneNumber phone;

        public Contact(NameValue pName, EmailValue pEmail, PhoneNumber pPhone)
        {
            this.name = pName;
            this.email = pEmail;
            this.phone = pPhone;
        }


        //email sea válido según las reglas habituales
        //teléfono tenga por lo menos 7 caracteres numéricos.

    }
}
