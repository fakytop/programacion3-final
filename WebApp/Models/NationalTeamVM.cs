using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class NationalTeamVM
    {
        public int Id { get; set; }
        public int idCountry { get; set; }
        //public Country Country { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Bettors { get; set; }
    }
}
