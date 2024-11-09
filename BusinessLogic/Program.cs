using System.Text.Json.Serialization;
using BusinessLogic.Data.Contexts;
using BusinessLogic.Repositories;
using DTO.Data;
using DTO.Data.Entities;
using DTO.Data.Models;
using ELOSystem;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MatchRepository>();
builder.Services.AddScoped<PlayerRepository>();
builder.Services.AddScoped<EloCalculator>();

builder.Services.AddDbContext<EloSystemContext>(options =>
{
    string? connectionString = builder.Configuration.GetConnectionString("EloSystemContext");
    if (connectionString == null)
    {
        throw new InvalidOperationException("Connection string is null");
    }

    options.UseSqlite(connectionString, optionsBuilder =>
        optionsBuilder.MigrationsAssembly("EloSystemAPI"));
});


var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<MatchEntity>(nameof(Match));
modelBuilder.EntitySet<PlayerEntity>(nameof(Player));
modelBuilder.EntitySet<PlayerMatchEntity>("PlayerMatches");
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .AddOData(
    options => options
        .EnableQueryFeatures()
        .AddRouteComponents(
            "odata/v4",
            modelBuilder.GetEdmModel()));

var app = builder.Build();
Log.Logger = new LoggerConfiguration().Enrich.FromLogContext()
    .Enrich.WithProperty("ApplicationName", "BusinessLogic")
    .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] {ApplicationName} {UserId} {Message:lj}{NewLine}{Exception}")
    .WriteTo.File("logs/businessLogic-.txt", rollingInterval: RollingInterval.Hour, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] [{ApplicationName}] [{UserId}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseODataQueryRequest();
app.UseAuthorization();

app.MapControllers();

app.Run();