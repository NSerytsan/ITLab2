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
        public ICollection<Column>? Columns { get; set; }
        [Required]
        [ForeignKey("DatabaseId")]
        public virtual Database? Database { get; set; }
    }
}