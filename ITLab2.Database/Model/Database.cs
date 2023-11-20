namespace ITLab2.Data.Model
{
    public class Database
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Table> Tables { get; set; } = [];
    }
}