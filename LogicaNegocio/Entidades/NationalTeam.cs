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

        //prueba 1 github

        //Controlar una seleccion por pais.
    }
}
