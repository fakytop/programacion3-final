using LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesDominio;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace LogicaNegocio.Entidades
{
    public class NationalTeam: IEntity, IValidate
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public NameValue Name { get; set; }
        public PhoneNumber Phone { get; set; }
        public EmailValue Email { get; set; }
        public PositiveIntegerValue Bettors { get; set; }
        public GroupStage GroupStage { get; set; }
        public int? GroupStageId { get; set; }

        public NationalTeam()
        {

        }

        public NationalTeam(Country pCountry, NameValue pName, PhoneNumber pPhone, EmailValue pEmail, PositiveIntegerValue pPunters)
        {
            this.Country = pCountry;
            this.Name = pName;
            this.Phone = pPhone;
            this.Email = pEmail;
            this.Bettors = pPunters;
        }


        public void Validate()
        {

        }
        public void Update(NationalTeam nt)
        {
            Country = nt.Country;
            Name = nt.Name;
            Phone = nt.Phone;
            Email = nt.Email;
            Bettors = nt.Bettors;
        }
    }
}
