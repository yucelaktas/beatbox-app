using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBox.DAL.ORM.Entity
{
    public class SongDetail 
    {
        [Key]
        public int SongDetailsId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Singer")]
        public int SingerId { get; set; }
        public virtual Singer Singer { get; set; }

        [MaxLength(250)]
        public string Lyrics { get; set; }

        [ForeignKey("Song")]
        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}
