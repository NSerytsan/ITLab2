using System.ComponentModel.DataAnnotations;

namespace ITLab2.Data.Model
{
    public class Database
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Table>? Tables { get; set; }
    }
}