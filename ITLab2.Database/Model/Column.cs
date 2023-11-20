namespace ITLab2.Data.Model
{
    public class Column
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required Type Type { get; set; }
    }
}
