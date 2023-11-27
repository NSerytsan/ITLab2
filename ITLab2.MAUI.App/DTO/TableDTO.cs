namespace ITLab2.MAUI.App.DTO
{
    public abstract class BaseTableDTO
    {
        public required string Name { get; set; }
    }

    public class TableDTO : BaseTableDTO
    {
        public int Id { get; set; }
        public IEnumerable<ColumnDTO> Columns { get; set; } = [];
    }

    public class CreateTableDTO : BaseTableDTO
    {
    }

    public class UpdateTableDTO : BaseTableDTO
    {
    }
}
