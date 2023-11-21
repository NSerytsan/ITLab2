using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITLab2.Data.Model
{
    public class Row
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public Dictionary<int, object>? Items { get; set; } = [];
        public string ItemsJson { get; set; } = string.Empty;
        public required Table Table { get; set; }
    }
}