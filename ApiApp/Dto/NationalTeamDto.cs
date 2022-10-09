﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Dto
{
    public class NationalTeamDto
    {
        public int Id { get; set; }
        [Required]
        public int idCountry { get; set; }
        //public Country Country { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int Bettors { get; set; }
    }
}