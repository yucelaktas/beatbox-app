using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBox.DAL.ORM.Entity
{
    public class Category: BaseEntity
    {
        [Column("CategoryDescription")]
        public string Description { get; set; }
        public virtual List<SongDetail> Songs { get; set; }

    }
}
