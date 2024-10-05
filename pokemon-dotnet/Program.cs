using Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using pokemon_dotnet;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAPIServices();
builder.Services.AddCoreServices();
builder.Services.AddInfraServices(builder.Configuration);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await ConfigureDatabaseAsync(app);
app.Run();

async Task ConfigureDatabaseAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
    await initializer.InitialiseAsync();
    await initializer.SeedAsync();
}
