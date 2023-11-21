using System.ComponentModel.DataAnnotations;

namespace ITLab2.Data.Model
{
    public class Database
    {
        [Key]
        [Required]
        public required string Name { get; set; }
        public virtual ICollection<Table>? Tables { get; set; }
    }
}