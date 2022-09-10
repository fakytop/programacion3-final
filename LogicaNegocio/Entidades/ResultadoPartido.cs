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
        public Partido Partido { get; set; }
        public Goles Goles;
        public Tarjetas Tarjetas { get; set; }
        public Puntos RepartoPuntos { get; set; }
    }
}
