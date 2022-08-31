using CpmPedidos.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Classe responsável para inverter as dependencias
DependencyInjection.Register(builder.Services);



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
