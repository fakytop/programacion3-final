using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.Entidades
{
    public class Country: IEntity
    {
        public int Id { get; set; }
        public NameValue Name { get; set; }
        public ISOAlfa3Value IsoAlfa3 { get; set; } 
        public PositiveFloatValue GDP { get; set; } 
        public PositiveIntegerValue Population { get; set; }
        //public ImagenBandera ImgBandera { get; set; } 
        public RegionValue Region { get; set; }
        
        
        /*public override bool Equals(object obj)
        {
            Pais unP = obj as Pais;
            return unP != null && unP.Nombre.Value() == Nombre.Value();
        }*/

        public void Validar()
        {
            string nombre = Name.Value.ToUpper();
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
