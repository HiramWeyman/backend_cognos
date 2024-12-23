using ApiCognosV1.Data;
using ApiCognosV1.Repositorio;
using ApiCognosV1.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ApiCognosV1.CognosMapper;
using DinkToPdf.Contracts;
using DinkToPdf;
using jsreport.Local;
using jsreport.Types;
using Microsoft.AspNetCore.Server.Kestrel.Core;

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
builder.Services.AddScoped<IProblemasMed_Repositorio, ProblemasMedRepositorio>();
builder.Services.AddScoped<IPrevioSalud_Repositorio, PrevioSaludRepositorio>();
builder.Services.AddScoped<IConsumoSust_Repositorio, ConsumoSustRepositorio>();
builder.Services.AddScoped<ITratamientoRepositorio, TratamientoRepositorio>();
builder.Services.AddScoped<IConsultaMRepositorio, ConsultaMRepositorio>();
builder.Services.AddScoped<IProbObjRepositorio, ProbObjRepositorio>();
builder.Services.AddScoped<ILineaVidaRepositorio, LineaVidaRepositorio>();
builder.Services.AddScoped<ISesionRepositorio, SesionRepositorio>();
builder.Services.AddScoped<IFormCasoRepositorio, FormCasoRepositorio>();
builder.Services.AddScoped<IComentariosRepositorio, ComentariosRepositorio>();
builder.Services.AddScoped<I_InformeRepositorio, InformeRepositorio>();
builder.Services.AddScoped<ITerapeutasRepositorio, TerapeutaRepositorio>();
builder.Services.AddScoped<IGeneroRepositorio, GeneroRepositorio>();
builder.Services.AddScoped<IEscolaridadRepositorio, EscolaridadRepositorio>();
builder.Services.AddScoped<IEdocivilRepositorio, EdocivilRepositorio>();
builder.Services.AddScoped<ICreenciasRepositorio, CreenciaRepositorio>();
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = 524288000; // 500 MB (ajustable según tus necesidades)
});

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.MaxRequestBodySize = 524288000; // 500 MB (ajustable según tus necesidades)
});



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
