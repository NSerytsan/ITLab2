using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ITLab2.Data.Model
{
    public class Row
    {
        [Key]
        public int Id { get; set; }
        public Dictionary<int, object>? Items { get; set; } = [];
        public required Table Table { get; set; }
    }
}