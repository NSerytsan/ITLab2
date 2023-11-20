using System.ComponentModel.DataAnnotations;

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
        public int DatabaseId { get; set; }
        public virtual Database? Database { get; set; }
    }
}