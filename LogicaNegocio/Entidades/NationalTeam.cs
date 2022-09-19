using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class NationalTeam: IEntity
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public Contact Contact { get; set; }
        public PositiveIntegerValue Punters { get; set; }

        public NationalTeam()
        {

        }

        public NationalTeam(Country pCountry, Contact pContact, PositiveIntegerValue pPunters)
        {
            this.Country = pCountry;
            this.Contact = pContact;
            this.Punters = pPunters;
        }


        public void Validate()
        {
            //TODO: Validar que no haya otra selección con el mismo país al ingresarlo. 
        }


        //prueba 1 github

        //Controlar una seleccion por pais.
    }
}
