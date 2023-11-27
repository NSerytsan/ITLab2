namespace ITLab2.MAUI.App.DTO
{
    public abstract class BaseDatabaseDTO
    {
        public required string Name { get; set; }
    }

    public class DatabaseDTO : BaseDatabaseDTO
    {
        public IEnumerable<TableDTO>? Tables { get; set; } = [];
    }

    public class CreateDatabaseDTO : BaseDatabaseDTO
    {
    }

    public class UpdateDatabaseDTO : BaseDatabaseDTO
    {
    }
}