using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Dto
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoAlfa3 { get; set; }
        public float GDP { get; set; }
        public int Population { get; set; }
        public string Image { get; set; }
        public string Region { get; set; }
    }
}
