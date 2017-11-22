using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBox.DAL.ORM.Entity
{
    public class BaseEntity
    {
        [Key, Column(Order = 1)]
        public int Id { get; set; }

        [Column(Order = 2), MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "Datetime2")]
        public DateTime? InsertDate { get; set; }

        [Column(TypeName = "Datetime2")]
        public DateTime? UpdateDate { get; set; }

        [Column(TypeName = "Datetime2")]
        public DateTime? DeleteDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
