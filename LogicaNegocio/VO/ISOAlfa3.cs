using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.VO
{
    public class ISOAlfa3
    {
        private string _value;
        // Es unico - 3 caracteres y comienza con la primera letra del pais.

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        protected ISOAlfa3()
        {
            _value = "Innominado";
        }
        public ISOAlfa3(string pCodigo)
        {
            if(pCodigo.Length != 3)
            {
                throw new DomainException("El código ISO-Alfa3 debe ser de 3 caracteres.");
            }

            this._value = pCodigo;
        }
    }
}