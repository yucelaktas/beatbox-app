using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeatBox.UI.Models.DTO
{
    public class SongWriterDTO : BaseDTO
    {
        public string Lastname { get; set; }

        public DateTime? BirthDayDate { get; set; }

        public string BirthPlace { get; set; }

        public string Descrition { get; set; }

    }
}