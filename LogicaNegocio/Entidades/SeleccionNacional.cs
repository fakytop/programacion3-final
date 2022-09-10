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
        public Pais Pais { get; set; }
        public Contacto Contacto { get; set; }
        public int Apostadores { get; set; }
        public Grupo GrupoMundial { get; set; }

        
        //Controlar una seleccion por pais.
    }
}
