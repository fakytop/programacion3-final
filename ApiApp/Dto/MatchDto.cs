using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Dto
{
    public class MatchDto
    {
        public int Id { get; set; }
        public int HomeId { get; set; }
        public int AwayId { get; set; }
        public int MatchResultId { get; set; }
        public DateTime MatchDate { get; set; }
    }
}
