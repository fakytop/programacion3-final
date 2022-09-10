using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.VO
{
    public class Poblacion
    {
        private int _value;

        public int Value
        {
            get{ return _value; }
            set { _value = value; }
        }

        protected Poblacion()
        {
            _value = -1;
        }

        public Poblacion(int pPoblacion)
        {
            if(pPoblacion < 0)
            {
                throw new DomainException("El campo población debe ser mayor que 0");
            }

            this._value = pPoblacion;
        }
    }
}
