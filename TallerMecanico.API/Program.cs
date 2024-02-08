using TallerMecanico.Business.DescuentosRecargos;
using TallerMecanico.Business.Desperfectos;
using TallerMecanico.Business.Presupuesto;
using TallerMecanico.Business.Repuesto;
using TallerMecanico.Business.Vehiculos;
using TallerMecanico.Common;
using TallerMecanico.DAL;
using TallerMecanico.DAL.Automovil;
using TallerMecanico.DAL.DescuentosRecargos;
using TallerMecanico.DAL.Desperfecto;
using TallerMecanico.DAL.DesperfectosRepuesto;
using TallerMecanico.DAL.DesperfectosRepuestosRepuesto;
using TallerMecanico.DAL.Moto;
using TallerMecanico.DAL.Presupuesto;
using TallerMecanico.DAL.Repuesto;
using TallerMecanico.DAL.Vehiculo;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration
 .SetBasePath(System.IO.Directory.GetCurrentDirectory())
 .AddJsonFile($"appsettings.json", optional: false)
 .AddJsonFile($"appsettings.Development.json", optional: true)
 .AddEnvironmentVariables()
 .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IAutomovilDAL, AutomovilDAL>();
builder.Services.AddSingleton<IMotoDAL, MotoDAL>();
builder.Services.AddSingleton<IDescuentosRecargosDAL, DescuentosRecargosDAL>();
builder.Services.AddSingleton<ICommonDAL, CommonDAL>();
builder.Services.AddSingleton<IVehiculoDAL, VehiculoDAL>();
builder.Services.AddSingleton<IPresupuestoDAL, PresupuestoDAL>();
builder.Services.AddSingleton<IRepuestoDAL, RepuestoDAL>();
builder.Services.AddSingleton<IDesperfectoDAL, DesperfectoDAL>();
builder.Services.AddSingleton<IDesperfectosRepuestoDAL, DesperfectosRepuestoDAL>();

builder.Services.AddSingleton<IConfigurationService, ConfigurationService>();
builder.Services.AddSingleton<IDescuentosRecargoBusiness, DescuentosRecargoBusiness>();
builder.Services.AddSingleton<IVehiculoBusiness, VehiculoBusiness>();
builder.Services.AddSingleton<IRepuestoBusiness, RepuestoBusiness>();
builder.Services.AddSingleton<IDesperfectoBusiness, DesperfectoBusiness>();
builder.Services.AddSingleton<IPresupuestoBusiness, PresupuestoBusiness>();
builder.Services.AddSingleton<IVehiculoBusiness, VehiculoBusiness>();

builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(typeof(Program));
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
