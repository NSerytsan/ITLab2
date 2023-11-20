namespace ITLab2.Data
{
    public class Database
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Table> Tables { get; set; } = [];
    }
}