using ITLab2.MAUI.App.DTO;

namespace ITLab2.MAUI.App.Services
{
    public interface IRestService
    {
        public Task<List<DatabaseDTO>> GetDatabasesAsync();
    }
}
