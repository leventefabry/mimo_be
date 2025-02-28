using Mimo.API;
using Mimo.Application;
using Mimo.Infrastructure;
using Mimo.Persistence;
using Mimo.Persistence.DataSeed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddSwaggerConfig();
builder.Services.AddAuthServices(builder.Configuration);
builder.Services.ConfigureDatabase(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    try
    {
        DbInitializer.InitDb(app.Services);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

app.Run();