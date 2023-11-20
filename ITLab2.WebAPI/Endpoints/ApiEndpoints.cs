using ITLab2.Data.Model;
using ITLab2.Data.Repository;
using ITLab2.DTO;

namespace ITLab2.WebAPI.Endpoints
{
    public static class ApiEndpoints
    {
        public static RouteGroupBuilder MapApiEndpoints(this IEndpointRouteBuilder routes)
        {
            var databasesGroup = routes.MapGroup("/database").WithOpenApi();

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

            return rowsGroup;
        }

        static IResult GetAllDatabases(IDatabaseRepository repository)
        {
            return TypedResults.Ok(repository.GetAll().Select(d => new DatabaseDTO(d)).ToList());
        }

        static IResult GetDatabase(int dbId, IDatabaseRepository repository)
        {
            return repository.Get(dbId)
                is Database database
                    ? TypedResults.Ok(new DatabaseDTO(database))
                    : TypedResults.NotFound();
        }

        static IResult CreateDatabase(CreateDatabaseDTO newDatabaseDTO, IDatabaseRepository repository)
        {
            var database = new Database
            {
                Name = newDatabaseDTO.Name
            };

            repository.Add(database);
            var databaseDTO = new DatabaseDTO(database);

            return TypedResults.Created($"/databases/{database.Id}", databaseDTO);
        }

        static IResult UpdateDatabase(int dbId, UpdateDatabaseDTO databaseDTO, IDatabaseRepository repository)
        {
            var database = repository.Get(dbId);
            if (database is null) return TypedResults.NotFound();
            database.Name = databaseDTO.Name;
            repository.Update(database);

            return TypedResults.NoContent();
        }

        static IResult DeleteDatabase(int dbId, IDatabaseRepository repository)
        {
            repository.Delete(dbId);
            return TypedResults.NoContent();
        }
    }
}
