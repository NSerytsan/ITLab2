namespace ITLab2.DTO
{
    public abstract class BaseColumnDTO
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
    }

    public class ColumnDTO : BaseColumnDTO
    {
        public int Id { get; set; }
    }

    public class CreateColumnDTO : BaseColumnDTO
    {
    }

    public class UpdateColumnDTO : BaseColumnDTO
    {
    }
}