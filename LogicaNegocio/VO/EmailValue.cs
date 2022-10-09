using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using LogicaNegocio.Excepciones;
using System.ComponentModel.DataAnnotations;

namespace LogicaNegocio.VO
{
    public class EmailValue
    {
        [EmailAddress]
        public string Value { get; private set; }
   
        public EmailValue (string value)
        {
            Value = value;
            //validate();
        }
        //public void validate ()
        //{
        //    Regex regex = new Regex(@"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*)+$");
        //    if (!regex.IsMatch (Value))
        //    {
        //        throw new InvalidEmailException("Invalid email: value must be a valid email.");
        //    } 
        //}
    }
}
