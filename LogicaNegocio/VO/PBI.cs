using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.VO
{
    public class PBI
    {
        private decimal _value;

        public decimal Value
        {
            get { return _value; }
            set { _value = value; }
        }
        protected PBI()
        {
            _value = -1;
        }

        public PBI(decimal pPBI)
        {
            if(pPBI < 0)
            {
                throw new DomainException("El PBI debe ser mayor a 0.");
            }
            this._value = pPBI;
        }
    }
}
