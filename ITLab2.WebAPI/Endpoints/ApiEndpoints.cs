using ITLab2.Data.Model;
using ITLab2.Data.Repository;
using ITLab2.DTO;
using ITLab2.DTO.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ITLab2.WebAPI.Endpoints
{
    public static class ApiEndPoints
    {
        public static void Map(WebApplication app)
        {
            var databasesGroup = app.MapGroup("/database").WithOpenApi();

            databasesGroup.MapGet("", GetAllDatabases);
            databasesGroup.MapGet("{dbName}", GetDatabase);
            databasesGroup.MapPost("", CreateDatabase);
            databasesGroup.MapDelete("{dbName}", DeleteDatabase);

            var tablesGroup = databasesGroup.MapGroup("{dbName}/tables");

            tablesGroup.MapGet("", GetAllTables);
            tablesGroup.MapGet("{tableName}", GetTable);
            tablesGroup.MapPost("", CreateTable);
            tablesGroup.MapPut("{tableName}", UpdateTable);
            tablesGroup.MapDelete("{tableName}", DeleteTable);

            var columnsGroup = tablesGroup.MapGroup("{tabId:int}/columns");

            columnsGroup.MapGet("", (string dbName, int tabId) =>
            {
            });

            columnsGroup.MapGet("{colName}", (string dbName, int tabId, string colName) =>
            {
            });

            columnsGroup.MapPost("", (string dbName, int tabId) =>
            {
            });

            columnsGroup.MapPut("{colName}", (string dbName, int tabId, string colName) =>
            {
            });

            columnsGroup.MapDelete("{colName}", (string dbName, int tabId, string colName) =>
            {
            });
        }

        private static async Task<IResult> GetAllDatabases(DatabaseStorage storage)
        {
            var databases = await storage.Databases.Include(d => d.Tables).ToListAsync();

            return TypedResults.Ok(databases.ToDatabaseDTOs());
        }

        private static async Task<IResult> GetDatabase(string dbName, DatabaseStorage storage)
        {
            return await storage.Databases.FindAsync(dbName)
                is Database database
                    ? TypedResults.Ok(database.ToDatabaseDTO())
                    : TypedResults.NotFound();
        }

        private static async Task<IResult> CreateDatabase(CreateDatabaseDTO newDatabaseDTO, DatabaseStorage storage)
        {
            if (await storage.Databases.FindAsync(newDatabaseDTO.Name) is not null) return TypedResults.BadRequest();

            var database = new Database
            {
                Name = newDatabaseDTO.Name
            };

            await storage.Databases.AddAsync(database);

            await storage.SaveChangesAsync();

            var databaseDTO = database.ToDatabaseDTO();

            return TypedResults.Created($"/databases/{database.Name}", databaseDTO);
        }

        private static async Task<IResult> DeleteDatabase(string dbName, DatabaseStorage storage)
        {
            if (await storage.Databases.FindAsync(dbName) is Database database)
            {
                storage.Databases.Remove(database);

                await storage.SaveChangesAsync();

                return TypedResults.NoContent();
            }

            return TypedResults.NotFound();
        }

        private static async Task<IResult> GetAllTables(string dbName, DatabaseStorage storage)
        {
            if (await storage.Databases.FindAsync(dbName) is null) return TypedResults.NotFound();

            var tables = await storage.Tables.Where(t => t.Database.Name.Equals(dbName)).ToArrayAsync();

            return TypedResults.Ok(tables.ToTableDTOs());
        }

        private static async Task<IResult> GetTable(string dbName, string tableName, DatabaseStorage storage)
        {
            if (await storage.Databases.FindAsync(dbName) is null) return TypedResults.NotFound();

            return await storage.Tables.FirstOrDefaultAsync(t => t.Name.Equals(tableName))
                is Table table
                    ? TypedResults.Ok(table.ToTableDTO())
                    : TypedResults.NotFound();
        }

        private static async Task<IResult> CreateTable(string dbName, CreateTableDTO newTableDTO, DatabaseStorage storage)
        {
            var database = await storage.Databases.FindAsync(dbName);

            if (database is null) return TypedResults.NotFound();

            var table = new Table
            {
                Name = newTableDTO.Name,
                Database = database
            };

            await storage.Tables.AddAsync(table);

            await storage.SaveChangesAsync();

            var tableDTO = table.ToTableDTO();

            return TypedResults.Created($"/databases/{database.Name}/tablses/{table.Id}", tableDTO);
        }

        private static async Task<IResult> UpdateTable(string dbName, string tableName, UpdateTableDTO tableDTO, DatabaseStorage storage)
        {
            var table = await storage.Tables.Include(t => t.Database).FirstOrDefaultAsync(t => t.Name.Equals(tableName));

            if (table is null) return TypedResults.NotFound();

            if (!table.Database.Name.Equals(dbName)) return TypedResults.NotFound();

            table.Name = tableDTO.Name;

            await storage.SaveChangesAsync();

            return TypedResults.NoContent();
        }

        private static async Task<IResult> DeleteTable(string dbName, string tableName, DatabaseStorage storage)
        {
            if (await storage.Databases.FindAsync(dbName) is null) TypedResults.NotFound();

            if (await storage.Tables.FirstOrDefaultAsync(t => t.Name.Equals(tableName)) is Table table)
            {
                storage.Tables.Remove(table);

                await storage.SaveChangesAsync();

                return TypedResults.NoContent();
            }

            return TypedResults.NotFound();
        }
    }
}