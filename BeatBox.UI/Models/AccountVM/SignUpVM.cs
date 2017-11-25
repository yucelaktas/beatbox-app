using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeatBox.UI.Models.AccountVM
{
    public class SignUpVM
    {
        [Required(ErrorMessage = "First is required."), Display(Name = "Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required.")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "E-mail field is required."), EmailAddress(ErrorMessage = "Invalid e-mail format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required."), RegularExpression(@"^[a-zA-Z]\w{3,14}", ErrorMessage = "The password's first character must be a letter, it must contain at least 4 characters and more than 15characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please mact the passwords"), Compare("Password", ErrorMessage = "Password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}