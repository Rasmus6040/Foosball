using System.Text.Json.Serialization;
using BusinessLogic.Data.Contexts;
using BusinessLogic.Repositories;
using DTO.Data;
using DTO.Data.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MatchRepository>();
builder.Services.AddScoped<PlayerRepository>();

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
modelBuilder.EntitySet<Match>(nameof(Match));
modelBuilder.EntitySet<Player>(nameof(Player));
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .AddOData(
    options => options
        .EnableQueryFeatures()
        .AddRouteComponents(
            "odata/v4",
            modelBuilder.GetEdmModel()));

var app = builder.Build();

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