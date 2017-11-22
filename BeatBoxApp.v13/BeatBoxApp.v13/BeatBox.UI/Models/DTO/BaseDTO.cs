using System;

namespace BeatBox.UI.Models.DTO
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? InsertDate { get; set; }

        public bool IsActive { get; set; }

    }
}