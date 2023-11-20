using ITLab2.Data.Model;

namespace ITLab2.DTO.Extensions
{
    public static partial class DTOConversions
    {
        public static DatabaseDTO ToDatabaseDTO(this Database database)
        {
            return new DatabaseDTO()
            {
                Id = database.Id,
                Name = database.Name
            };
        }

        public static IEnumerable<DatabaseDTO> ToDatabaseDTOs(this IEnumerable<Database> databases)
        {
            return from database in databases
                   select database.ToDatabaseDTO();
        }
    }
}