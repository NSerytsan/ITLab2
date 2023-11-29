namespace ITLab2.MAUI.App.DTO
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

    public class GetRowDTO
    {
        public Dictionary<string, string> Items { get; set; } = [];
    }
}