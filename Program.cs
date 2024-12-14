//ARCHIVO DE INSTRUCCIONES SUPERIOR
using ApiPersonalSalud.CAD;
using ApiPersonalSalud.CAD.Interfaces;
using ApiPersonalSalud.CLN;
using ApiPersonalSalud.CLN.Interfaces;
using Microsoft.EntityFrameworkCore;

//CREACION DE UN BUILDER
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CONTENEDOR DE DEPENDENCIAS
builder.Services.AddScoped<ICLNGestante,CLNGestante>();
builder.Services.AddScoped<ICLNUsuario,CLNUsuario>();
builder.Services.AddScoped<ICADGestante,CADGestante>();
builder.Services.AddScoped<ICADUsuario,CADUsuario>();

//El contenedor de servicios le toca saber como configurar el DBContext y con que opciones debe inicializarse
builder.Services.AddDbContext<ApplicationDBContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
