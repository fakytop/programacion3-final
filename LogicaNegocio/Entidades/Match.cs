using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Entidades
{
    public class Match: IEntity
    {
        public int Id { get; set; }
        public NationalTeam Local { get; set; }
        public NationalTeam Visita { get; set; }

        //Verificar que no jueguen contra si mismo, no puede haber otro partido en esa fecha y horario. 
    }
}
