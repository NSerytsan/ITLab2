namespace ITLab2.Data
{
    public class Table(Database database)
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Column> Columns { get; set; } = [];
        public Database Database { get; set; } = database;
    }
}