using Facturacion.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FacturacionContext>(options =>
    options.UseSqlServer(builder.Configuration["LocalConnectionString"]));

//add-migration MigracionInicial -Project Facturacion.Infrastructure -StartupProject Facturacion.WebApi
//remove-migration -Project Facturacion.Infrastructure -StartupProject Facturacion.WebApi
//Update-Database

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
