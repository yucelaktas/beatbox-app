using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeatBox.UI.Models.AccountVM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email field can not be blank.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field can not be blank.")]
        public string Password { get; set; }
    }
}