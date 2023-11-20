using ITLab2.Data.Model;
using ITLab2.Data.Repository;
using ITLab2.DTO;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IDatabaseRepository, DatabaseRepository>();

builder.Services.AddDbContext<DatabaseStorage>(opt => opt.UseInMemoryDatabase("DBMS"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var databases = app.MapGroup("/database").WithOpenApi();

databases.MapGet("", (IDatabaseRepository repository) => repository.GetAll().Select(d => new DatabaseDTO(d)));
databases.MapGet("{dbId:int}", GetDatabase);
databases.MapPost("", CreateDatabase);
databases.MapPut("{dbId:int}", UpdateDatabase);
databases.MapDelete("{dbId:int}", DeleteDatabase);

var tables = databases.MapGroup("{dbId:int}/tables");

tables.MapGet("", (int dbId) =>
{
});

tables.MapGet("{tabId:int}", (int dbId, int tabId) =>
{
});

tables.MapPost("", (int dbId) =>
{
});

tables.MapPut("{tabId:int}", (int dbId, int tabId) =>
{
});

tables.MapDelete("{tabId:int}", (int dbId, int tabId) =>
{
});

var rows = tables.MapGroup("{tabId:int}/rows");

rows.MapGet("", (int dbId, int tabId) =>
{
});

rows.MapGet("{rowId:int}", (int dbId, int tabId, int rowId) =>
{
});

rows.MapPost("", (int dbId, int tabId) =>
{
});

rows.MapPut("{rowId:int}", (int dbId, int tabId, int rowId) =>
{
});

rows.MapDelete("{rowId:int}", (int dbId, int tabId, int rowId) =>
{
});

app.Run();

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
