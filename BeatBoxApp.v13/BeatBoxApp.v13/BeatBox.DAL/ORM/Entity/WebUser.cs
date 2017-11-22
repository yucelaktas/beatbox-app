using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBox.DAL.ORM.Entity
{
    public class WebUser : BaseEntity
    {
        [MinLength(3),MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MinLength(4), MaxLength(8)]
        public string Password { get; set; }
        [MaxLength(8)]
        public string Role { get; set; }
    }
}
