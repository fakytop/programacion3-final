using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class Partido: IEntity
    {
        public int Id { get; set; }
        public SeleccionNacional Local { get; set; }
        public SeleccionNacional Visita { get; set; }
        public FechaPartido FechaPartido { get; set; }

        //Verificar que no jueguen contra si mismo, no puede haber otro partido en esa fecha y horario. 
    }
}
