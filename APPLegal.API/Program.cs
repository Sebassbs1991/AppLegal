using AppLegal.Repositorio.Contrato;
using AppLegal.Repositorio.DBContext;
using AppLegal.Repositorio.Implementacion;
using AppLegal.Utilidades;
using Microsoft.EntityFrameworkCore;

using AppLegal.Servicio.Contrato;
using AppLegal.Servicio.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbLegalProContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL"));
});

builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<ICasoServicio, CasoServicio>();
builder.Services.AddScoped<IDocumentoServicio, DocumentoServicio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IEventoServicio, EventoServicio>();
builder.Services.AddScoped<ITareaServicio, TareaServicio>();
 builder.Services.AddCors(options =>
 {
     options.AddPolicy("Nueva Politica", app =>
     { 
            app.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyMethod();
     });
 });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
