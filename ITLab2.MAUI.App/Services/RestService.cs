
using ITLab2.MAUI.App.DTO;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace ITLab2.MAUI.App.Services
{
    internal class RestService : IRestService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;

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
            var databases = new List<DatabaseDTO>();
            Uri uri = new(string.Format(Constants.DatabasesRestUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    databases = JsonSerializer.Deserialize<List<DatabaseDTO>>(content, _serializerOptions) ?? [];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }

            return databases;
        }

        public async Task CreateDatabaseAsync(CreateDatabaseDTO database)
        {
            Uri uri = new(string.Format(Constants.DatabasesRestUrl, string.Empty));
            try
            {
                string json = JsonSerializer.Serialize<CreateDatabaseDTO>(database, _serializerOptions);
                StringContent content = new(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(uri, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
        }

        public async Task DeleteDatabaseAsync(string dbName)
        {
            Uri uri = new(string.Format(Constants.DatabasesRestUrl, dbName));

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
        }

        public async Task<List<TableDTO>> GetTablesAsync(string dbName)
        {
            var tables = new List<TableDTO>();
            Uri uri = new(string.Format(Constants.TablesRestUrl, dbName, string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    tables = JsonSerializer.Deserialize<List<TableDTO>>(content, _serializerOptions) ?? [];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }

            return tables;
        }

        public async Task CreateTableAsync(CreateTableDTO table, string dbName)
        {
            Uri uri = new(string.Format(Constants.TablesRestUrl, dbName, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<CreateTableDTO>(table, _serializerOptions);
                StringContent content = new(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(uri, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
        }

        public async Task DeleteTableAsync(string dbName, string tableName)
        {
            Uri uri = new(string.Format(Constants.TablesRestUrl, dbName, tableName));

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
        }

        public async Task<List<ColumnDTO>> GetColumnsAsync(string dbName, string tableName)
        {
            var columns = new List<ColumnDTO>();
            Uri uri = new(string.Format(Constants.ColumnsRestUrl, dbName, tableName, string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    columns = JsonSerializer.Deserialize<List<ColumnDTO>>(content, _serializerOptions) ?? [];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }

            return columns;
        }

        public async Task CreateColumnAsync(CreateColumnDTO column, string dbName, string tableName)
        {
            Uri uri = new(string.Format(Constants.ColumnsRestUrl, dbName, tableName, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<CreateColumnDTO>(column, _serializerOptions);
                StringContent content = new(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(uri, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
        }

        public async Task DeleteColumnAsync(string dbName, string tableName, string columnName)
        {
            Uri uri = new(string.Format(Constants.ColumnsRestUrl, dbName, tableName, columnName));

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
        }


        public async Task<List<GetRowDTO>> GetRowsAsync(string dbName, string tableName)
        {
            var rows = new List<GetRowDTO>();
            Uri uri = new(string.Format(Constants.RowsRestUrl, dbName, tableName, string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    rows = JsonSerializer.Deserialize<List<GetRowDTO>>(content, _serializerOptions) ?? [];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }

            return rows;
        }

        public async Task CreateRowAsync(CreateRowDTO row, string dbName, string tableName)
        {
            Uri uri = new(string.Format(Constants.RowsRestUrl, dbName, tableName, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<CreateRowDTO>(row, _serializerOptions);
                StringContent content = new(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(uri, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
        }

        public async Task DeleteRowAsync(string dbName, string tableName, int rowId)
        {
            Uri uri = new(string.Format(Constants.RowsRestUrl, dbName, tableName, rowId));

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
        }
    }
}
