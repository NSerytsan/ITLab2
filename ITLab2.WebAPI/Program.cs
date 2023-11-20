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

app.MapGet("/databases", () =>
 {
 })
.WithName("GetDataBases")
.WithOpenApi();

app.MapGet("/databases/{dbId}", (string dbId) =>
{
})
.WithName("GetDataBase")
.WithOpenApi();

app.MapPost("/databases", () =>
{
})
.WithName("CreateDatabase")
.WithOpenApi();

app.MapPut("/databases", () =>
{
})
.WithName("UpdateDatabase")
.WithOpenApi();

app.MapDelete("/databases/{dbId}", (string dbId) =>
{
})
.WithName("DeleteDataBase")
.WithOpenApi();

app.MapGet("/databases/{dbId}/tables", (string dbId) =>
{
})
.WithName("GetTables")
.WithOpenApi();

app.MapGet("/databases/{dbId}/tables/{tabId}", (string dbId, string tabId) =>
{
})
.WithName("GetTable")
.WithOpenApi();

app.MapPost("/databases/{dbId}/tables", (string dbId) =>
{
})
.WithName("CreateTable")
.WithOpenApi();

app.MapPut("/databases/{dbId}/tables", (string dbId) =>
{
})
.WithName("UpdateTable")
.WithOpenApi();

app.MapDelete("/databases/{dbId}/tablse/{tabId}", (string dbId, string tabId) =>
{
})
.WithName("DeleteTable")
.WithOpenApi();

app.MapGet("/databases/{dbId}/tables/{tabId}/rows", (string dbId, string tabId) =>
{
})
.WithName("GetRows")
.WithOpenApi();

app.MapGet("/databases/{dbId}/tables/{tabId}/rows/{rowId}", (string dbId, string tabId, string rowId) =>
{
})
.WithName("GetRow")
.WithOpenApi();

app.MapPost("/databases/{dbId}/tables/{tabId}/rows", (string dbId, string tabId) =>
{
})
.WithName("CreateRows")
.WithOpenApi();

app.MapPut("/databases/{dbId}/tables/{tabId}/rows", (string dbId, string tabId) =>
{
})
.WithName("UpdateRows")
.WithOpenApi();

app.MapDelete("/databases/{dbId}/tablse/{tabId}/rows/{rowId}", (string dbId, string tabId, string rowId) =>
{
})
.WithName("DeleteRows")
.WithOpenApi();

app.Run();