namespace ITLab2.Data.Model
{
    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
       // public List<Column> Columns { get; set; } = [];
        public Database? Database { get; set; }
    }
}