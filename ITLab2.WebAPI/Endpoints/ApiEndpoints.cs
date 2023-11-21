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
            tablesGroup.MapGet("{tabId:int}", GetTable);
            tablesGroup.MapPost("", CreateTable);
            tablesGroup.MapPut("{tabId:int}", UpdateTable);
            tablesGroup.MapDelete("{tabId:int}", DeleteTable);

            var rowsGroup = tablesGroup.MapGroup("{tabId:int}/rows");

            rowsGroup.MapGet("", (int dbId, int tabId) =>
            {
            });

            rowsGroup.MapGet("{rowId:int}", (int dbId, int tabId, int rowId) =>
            {
            });

            rowsGroup.MapPost("", (int dbId, int tabId) =>
            {
            });

            rowsGroup.MapPut("{rowId:int}", (int dbId, int tabId, int rowId) =>
            {
            });

            rowsGroup.MapDelete("{rowId:int}", (int dbId, int tabId, int rowId) =>
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
            if (await storage.Databases.FindAsync(dbName) is null) return TypedResults.BadRequest();

            var tables = await storage.Tables.Where(t => t.Database.Name.Equals(dbName)).ToArrayAsync();

            return TypedResults.Ok(tables.ToTableDTOs());
        }

        private static async Task<IResult> GetTable(string dbName, int tabId, DatabaseStorage storage)
        {
            if (await storage.Databases.FindAsync(dbName) is null) return TypedResults.BadRequest();

            return await storage.Tables.FindAsync(tabId)
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

        private static async Task<IResult> UpdateTable(string dbName, int tabId, UpdateTableDTO tableDTO, DatabaseStorage storage)
        {
            var table = await storage.Tables.FindAsync(tabId);

            if (table is null) return TypedResults.NotFound();

            if (!table.Database.Name.Equals(dbName)) return TypedResults.BadRequest();

            table.Name = tableDTO.Name;

            await storage.SaveChangesAsync();

            return TypedResults.NoContent();
        }

        private static async Task<IResult> DeleteTable(string dbName, int tabId, DatabaseStorage storage)
        {
            if (await storage.Databases.FindAsync(dbName) is null) TypedResults.BadRequest();

            if (await storage.Tables.FindAsync(tabId) is Table table)
            {
                storage.Tables.Remove(table);

                await storage.SaveChangesAsync();

                return TypedResults.NoContent();
            }

            return TypedResults.NotFound();
        }
    }
}