using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.Entidades
{
    public class Pais: IEntity
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; } // Solo alfabetico y espacios embebidos - es unico
        public ISOAlfa3 IsoAlfa3 { get; set; } 
        public PBI PBI { get; set; } 
        public Poblacion Poblacion { get; set; }
        //public ImagenBandera ImgBandera { get; set; } 
        public Region Region { get; set; }
        
        
        /*public override bool Equals(object obj)
        {
            Pais unP = obj as Pais;
            return unP != null && unP.Nombre.Value() == Nombre.Value();
        }*/

        public void Validar()
        {
            string nombre = Nombre.Value.ToUpper();
            string alfa3 = IsoAlfa3.Value.ToUpper();

            char chNombre = nombre[0];
            char chAlfa3 = alfa3[0];

            if(chNombre != chAlfa3)
            {
                throw new DomainException("La inicial del país y el codio Alfa3 deben coincidir.");
            }
        }
    }

    
}
