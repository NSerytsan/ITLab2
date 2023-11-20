using ITLab2.Data.Model;

namespace ITLab2.DTO
{
    public class DatabaseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public DatabaseDto() { }
        public DatabaseDto(Database database) => (Id, Name) = (database.Id, database.Name);
    }
}
