namespace ITLab2.DTO
{

    public abstract class BaseDatabaseDTO
    {
        public string? Name { get; set; }
    }

    public class DatabaseDTO : BaseDatabaseDTO
    {
        public int Id { get; set; }
    }

    public class CreateDatabaseDTO : BaseDatabaseDTO
    {
    }
}