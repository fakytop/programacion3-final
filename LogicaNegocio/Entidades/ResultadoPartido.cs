using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class ResultadoPartido: IEntity
    {
        public int Id { get; set; }
        public Match Partido { get; set; }
        public Tarjetas Tarjetas { get; set; }
    }
}

//Prueba 2 de github
