using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class NationalTeamVM
    {
        public int Id { get; set; }
        [Required]
        public int idCountry { get; set; }
        //public Country Country { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int Bettors { get; set; }
    }
}
