using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomAuth.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = "The field can not be empty!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "The field can not be empty!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}