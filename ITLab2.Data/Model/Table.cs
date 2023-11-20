using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITLab2.Data.Model
{
    public class Table
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public virtual ICollection<Column>? Columns { get; set; }
        [Required]
        [ForeignKey("DatabaseId")]
        public virtual required Database Database { get; set; }
    }
}