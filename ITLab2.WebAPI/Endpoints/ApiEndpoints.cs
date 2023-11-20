﻿using ITLab2.Data.Model;
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
            databasesGroup.MapGet("{dbId:int}", GetDatabase);
            databasesGroup.MapPost("", CreateDatabase);
            databasesGroup.MapPut("{dbId:int}", UpdateDatabase);
            databasesGroup.MapDelete("{dbId:int}", DeleteDatabase);

            var tablesGroup = databasesGroup.MapGroup("{dbId:int}/tables");

            tablesGroup.MapGet("", (int dbId) =>
            {
            });

            tablesGroup.MapGet("{tabId:int}", (int dbId, int tabId) =>
            {
            });

            tablesGroup.MapPost("", (int dbId) =>
            {
            });

            tablesGroup.MapPut("{tabId:int}", (int dbId, int tabId) =>
            {
            });

            tablesGroup.MapDelete("{tabId:int}", (int dbId, int tabId) =>
            {
            });

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
            var databases = await storage.Databases.ToListAsync();

            return TypedResults.Ok(databases.ToDatabaseDTOs());
        }

        private static async Task<IResult> GetDatabase(int dbId, DatabaseStorage storage)
        {
            return await storage.Databases.FindAsync(dbId)
                is Database database
                    ? TypedResults.Ok(database.ToDatabaseDTO())
                    : TypedResults.NotFound();
        }

        private static async Task<IResult> CreateDatabase(CreateDatabaseDTO newDatabaseDTO, DatabaseStorage storage)
        {
            var database = new Database
            {
                Name = newDatabaseDTO.Name
            };

            await storage.Databases.AddAsync(database);

            await storage.SaveChangesAsync();

            var databaseDTO = database.ToDatabaseDTO();

            return TypedResults.Created($"/databases/{database.Id}", databaseDTO);
        }

        private static async Task<IResult> UpdateDatabase(int dbId, UpdateDatabaseDTO databaseDTO, DatabaseStorage storage)
        {
            var database = await storage.Databases.FindAsync(dbId);

            if (database is null) return TypedResults.NotFound();

            database.Name = databaseDTO.Name;

            await storage.SaveChangesAsync();

            return TypedResults.NoContent();
        }

        private static async Task<IResult> DeleteDatabase(int dbId, DatabaseStorage storage)
        {
            if (await storage.Databases.FindAsync(dbId) is Database database)
            {
                storage.Databases.Remove(database);

                await storage.SaveChangesAsync();

                return TypedResults.NoContent();
            }

            return TypedResults.NotFound();
        }
    }
}