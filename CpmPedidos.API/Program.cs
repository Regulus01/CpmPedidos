using CpmPedidos.API;
using System.Data.Common;
using CpmPedidos.Repository;
using Npgsql;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("App");
DbConnection DbConnection = new NpgsqlConnection(connectionString);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(DbConnection, assembly => 
    assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
});

builder.Services.AddControllers()
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = 
    Newtonsoft.Json.ReferenceLoopHandling.Ignore);

//Classe responsável para inverter as dependencias
DependencyInjection.Register(builder.Services);



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
