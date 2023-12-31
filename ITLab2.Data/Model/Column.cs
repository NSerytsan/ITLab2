﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITLab2.Data.Model
{
    public class Column
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Type { get; set; }
        [Required]
        [ForeignKey("TableId")]
        public virtual required Table Table { get; set; }
    }
}
