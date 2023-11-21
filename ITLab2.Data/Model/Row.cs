using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITLab2.Data.Model
{
    public class Row
    {
        [Key]
        public int Id { get; set; }
        public required string ItemsJson { get; set; } = string.Empty;
        public required Table Table { get; set; }
    }
}