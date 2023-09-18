using Carter;
using Microsoft.EntityFrameworkCore;
using UrlShortner.App.Shared.Configuration;
using UrlShortner.App.Shared.Extensions;
using UrlShortner.App.Shared.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services
    .AddCarter()
    .AddMemoryCache()
    .AddDbContext<ApplicationDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetSection("ConnectionString");

        options.UseSqlServer(connectionString.Value);
    })
    .AddRepository()
    .AddHttpContextAccessor();

builder.Services.AddMediatR(UrlShortner.App.AssemblyReference.Assembly);

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.ApplyMigrations();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapCarter();

app.Run();

public partial class Program { }