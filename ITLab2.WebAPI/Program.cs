using ITLab2.Data.Model;
using ITLab2.Data.Repository;
using ITLab2.DTO;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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

databases.MapGet("", getAllDatabases);
databases.MapGet("{dbId:int}", GetDatabase);
databases.MapPost("", CreateDatabase);

databases.MapPut("{dbId:int}", (int dbId) =>
{
});

databases.MapDelete("{dbId:int}", (int dbId) =>
{
});

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

static async Task<IResult> getAllDatabases(DatabaseStorage repo)
{
    return TypedResults.Ok(await repo.Databases.Select(d => new DatabaseDTO(d)).ToArrayAsync());
}

static async Task<IResult> GetDatabase(int dbId, DatabaseStorage repo)
{
    return await repo.Databases.FindAsync(dbId)
        is Database database
            ? TypedResults.Ok(new DatabaseDTO(database))
            : TypedResults.NotFound();
}

static async Task<IResult> CreateDatabase(DatabaseDTO databaseDTO, DatabaseStorage repo)
{
    var database = new Database
    {
        Name = databaseDTO.Name
    };

    repo.Databases.Add(database);
    await repo.SaveChangesAsync();

    databaseDTO = new DatabaseDTO(database);

    return TypedResults.Created($"/databases/{database.Id}", databaseDTO);
}
