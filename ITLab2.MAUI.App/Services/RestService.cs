
using ITLab2.MAUI.App.DTO;
using System.Diagnostics;
using System.Text.Json;

namespace ITLab2.MAUI.App.Services
{
    internal class RestService : IRestService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;

        public List<DatabaseDTO> Databases { get; private set; } = [];
        public RestService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<List<DatabaseDTO>> GetDatabasesAsync()
        {
            Uri uri = new(string.Format(Constants.DatabasesRestUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Databases = JsonSerializer.Deserialize<List<DatabaseDTO>>(content, _serializerOptions) ?? [];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }

            return Databases;
        }
    }
}
