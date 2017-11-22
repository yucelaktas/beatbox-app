using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBox.DAL.ORM.Entity
{
    public class Singer : BaseEntity
    {
        [MinLength(3), MaxLength(30)]
        public string Lastname { get; set; }

        [Column(TypeName = "Datetime2")]
        public DateTime? BirthDayDate { get; set; }

        [MaxLength(30)]
        public string BirthPlace { get; set; }

        public virtual List<SongDetail> SongDetails { get; set; }

        [MaxLength(250)]
        public string Descrition { get; set; }
    }
}
