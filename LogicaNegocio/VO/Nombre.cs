using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.VO
{
    public class Nombre
    {
        private string _value;
        //Tanto para nombre de pais como de contacto debemos controlar que solo sea alfabetico.
        
        protected Nombre()
        {
            _value = "Innominado";
        }
        
        public Nombre(string pNombre)
        {
            if (!NameControl(pNombre))
            {
                throw new DomainException("El nombre solo admite caracteres alfabéticos.");
            }
                
            this._value = pNombre.Trim();
            
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private bool NameControl(string nombre)
        {
            bool valorRetorno = true;
            byte[] asciiBytes = Encoding.ASCII.GetBytes(nombre);
            foreach (byte item in asciiBytes)
            {
                bool condAlfabeto = item > 64 && item < 91
                                    || item > 96 && item < 123
                                    || item > 127 && item < 155
                                    || item > 159 && item < 166
                                    || item > 180 && item < 184
                                    || item > 197 && item < 200;
                if(!condAlfabeto)
                {
                    valorRetorno = false;
                    break;
                }
            }

            return valorRetorno;
        } 


    }
}
