using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.VO
{
    public class RegionValue
    {
        public string Value { get; private set;}
        public RegionValue(string value)
        {
            Value = value;
            validate();
        }
        public void validate ()
        {
            if (Value != "África" && Value != "América" && Value != "Asia" && Value != "Europa" && Value != "Oceanía")
            {
                throw new InvalidRegionException("Invalid region: value must be either África, América, Asia, Europa or Oceanía.");
            }
        }
    }
}
