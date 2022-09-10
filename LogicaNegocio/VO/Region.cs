using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.VO
{
    public class Region
    {
        private string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        protected Region()
        {
            _value = "Innominado";
        }
        public Region(string pNombre)
        {
            string nombreSinEspacios = pNombre.Trim();
                
            if (!regionControl(nombreSinEspacios))
            {
                throw new DomainException("Debe elegir una región disponible --> Africa / America / Asia / Europa / Oceania");
            }
            
            this._value = nombreSinEspacios;
        }

        private bool regionControl(string nombre)
        {
            bool valorResultado = true;
            if (nombre != "Africa"
                && nombre != "America"
                && nombre != "Europa"
                && nombre != "Asia"
                && nombre != "Oceania")
            {
                valorResultado = false;
            }
            return valorResultado;
        }
    }
}
