using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class SeleccionNacional: IEntity
    {
        public int Id { get; set; }
        public Country Pais { get; set; }
        public EmailValue Contacto { get; set; }
        public int Apostadores { get; set; }

        //prueba 1 github

        //Controlar una seleccion por pais.
    }
}
