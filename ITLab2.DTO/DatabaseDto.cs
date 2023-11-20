using ITLab2.Data.Model;

namespace ITLab2.DTO
{
    public class DatabaseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public DatabaseDTO() { }
        public DatabaseDTO(Database database) => (Id, Name) = (database.Id, database.Name);
    }

    public class CreateDatabaseDTO
    {
        public string? Name { get; set; }
    }

    public class UpdateDatabaseDTO
    {
        public string? Name { get; set; }
    }
}