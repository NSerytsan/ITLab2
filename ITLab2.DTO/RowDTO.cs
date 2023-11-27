namespace ITLab2.DTO
{
    public abstract class BaseRowDTO
    {
        public Dictionary<int, object> Items { get; set; } = [];
    }

    public class RowDTO : BaseRowDTO
    {
        public int Id { get; set; }
    }

    public class CreateRowDTO : BaseRowDTO
    {
    }

    public class UpdateRowDTO : BaseRowDTO
    {
    }
}