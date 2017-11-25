using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBox.DAL.ORM.Entity
{
    public class Song : BaseEntity
    {
        [ForeignKey("Songwriter")]
        public int SongwriterId { get; set; }
        public virtual SongWriter Songwriter { get; set; }

        [ForeignKey("Melodist")]
        public int MelodistId { get; set; }
        public virtual Melodist Melodist { get; set; }

        [Column(TypeName = "Datetime2")]
        public DateTime? ReleaseDate { get; set; }


    }
}
