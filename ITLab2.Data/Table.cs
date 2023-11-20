namespace ITLab2.Data
{
    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Column> Columns { get; set; } = [];
        public Database Database { get; set; }

        public Table(Database database)
        { 
            Database = database;
        }
    }
}