using ITLab2.MAUI.App.DTO;

namespace ITLab2.MAUI.App.Services
{
    public interface IRestService
    {
        public Task<List<DatabaseDTO>> GetDatabasesAsync();
        public Task CreateDatabaseAsync(CreateDatabaseDTO database);
        public Task DeleteDatabaseAsync(string dbName);

        public Task<List<TableDTO>> GetTablesAsync(string dbName);
        public Task CreateTableAsync(CreateTableDTO table, string dbName);
        public Task DeleteTableAsync(string dbName, string tableName);

        public Task<List<ColumnDTO>> GetColumnsAsync(string dbName, string tableName);
        public Task CreateColumnAsync(CreateColumnDTO table, string dbName, string tableName);
        public Task DeleteColumnAsync(string dbName, string tableName, string columnName);

        public Task CreateRowAsync(CreateRowDTO row, string dbName, string tableName);
        public Task<List<GetRowDTO>> GetRowsAsync(string dbName, string tableName);
        public Task DeleteRowAsync(string dbName, string tableName, int rowId);
    }
}
