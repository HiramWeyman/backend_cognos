using ApiCognosV1.Data;
using ApiCognosV1.Repositorio;
using ApiCognosV1.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ApiCognosV1.CognosMapper;

var builder = WebApplication.CreateBuilder(args);

//Configurar Conexion a SqlServer
builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql"));
});

//Agregar los repositorios
builder.Services.AddScoped<IPerfilesRepositorio, PerfilesRepositorio>();
builder.Services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();
builder.Services.AddScoped<IPacientesRepositorio,PacientesRepositorio>();
builder.Services.AddScoped<ISaludFM_Repositorio, SaludFM_Repositorio>();
builder.Services.AddScoped<IAnalisisFU_Repositorio, AnalisisFU_Repositorio>();
builder.Services.AddScoped<IEvolucionPR_Repositorio, EvolucionPR_Repositorio>();
builder.Services.AddScoped<IOtrasAR_Repositorio, OtrasAR_Repositorio>();
builder.Services.AddScoped<IDiagnosticoDS_Repositorio, DiagnosticoDS_Repositorio>();

//Agregar el mapper
builder.Services.AddAutoMapper(typeof(CognosMapper));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Soporte para cors
//Se puede habilitas 1-dominio 2-multiples dominios
//3-cualquier dominio (Tener en cuenta la seguridad)
//Usamos de ejemplo el dominio https://localhost:3223, se debe cambiar por el correcto
//Se usa (*) para todos los dominios 

builder.Services.AddCors(p => p.AddPolicy("PolicyCors", build => 
{
    //build.WithOrigins("https://localhost:3223").AllowAnyMethod().AllowAnyHeader();
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Soporte para cors
app.UseCors("PolicyCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
