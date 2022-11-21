using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Dto
{
    public class NationalTeamDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Can't be null.")]

        public int idCountry { get; set; }
        public CountryDto Country { get; set; }
        [Required(ErrorMessage = "Can't be null.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Can't be null.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Can't be null.")]
        [EmailAddress(ErrorMessage ="Email is not valid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Can't be null.")]
        [Range(0, int.MaxValue,ErrorMessage = "Bettors must be positive.")]
        public int Bettors { get; set; }
    }
}
