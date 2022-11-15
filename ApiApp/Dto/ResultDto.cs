using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Dto
{
    public class ResultDto
    {
        public string country { get; set; }
        public int pts { get; set; }
        public int goalScored { get; set; }
        public int goalAgainst { get; set; }
        public int yellowCards { get; set; }
        public int redCards { get; set; }
        public int directRedCards { get; set; }
    }
}
