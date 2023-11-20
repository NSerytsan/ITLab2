var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var databases = app.MapGroup("/database").WithOpenApi();

databases.MapGet("", () =>
 {
 });

databases.MapGet("{dbId:int}", (int dbId) =>
{
});

databases.MapPost("", () =>
{
});

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