using ITLab2.Data.Model;

namespace ITLab2.DTO.Extensions
{
    public static partial class DTOConversions
    {
        public static DatabaseDTO ToDatabaseDTO(this Database database)
        {
            return new DatabaseDTO()
            {
                Name = database.Name,
                Tables = (database.Tables is not null) ?
                from table in database.Tables
                select new TableDTO()
                {
                    Id = table.Id,
                    Name = table.Name
                } : []
            };
        }

        public static IEnumerable<DatabaseDTO> ToDatabaseDTOs(this IEnumerable<Database> databases)
        {
            return from database in databases
                   select database.ToDatabaseDTO();
        }

        public static TableDTO ToTableDTO(this Table table)
        {
            return new TableDTO()
            {
                Id = table.Id,
                Name = table.Name
            };
        }

        public static IEnumerable<TableDTO> ToTableDTOs(this IEnumerable<Table> tables)
        {
            return from table in tables
                   select table.ToTableDTO();
        }

        public static ColumnDTO ToColumnDTO(this Column column)
        {
            return new ColumnDTO()
            {
                Id = column.Id,
                Name = column.Name,
                Type = column.Type
            };
        }

        public static IEnumerable<ColumnDTO> ToColumnDTOs(this IEnumerable<Column> columns)
        {
            return from column in columns
                   select column.ToColumnDTO();
        }
    }
}