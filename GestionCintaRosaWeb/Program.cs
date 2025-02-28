using CapaDatos;
using CapaDatos.Interfaces;
using CapaDatos.Repositorios;
using CapaLogica.Interfaces;
using CapaLogica.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Repositorios
builder.Services.AddScoped<IPacienteRepository, PacientesRepository>();
builder.Services.AddScoped<IConsultasRepository, ConsultasRepository>();
builder.Services.AddScoped<IDiagnosticosRepository, DiagnosticosRepository>();
builder.Services.AddScoped<ITratamientosRepository, TratamientosRepository>();
builder.Services.AddScoped<IMedicosRepository, MedicosRepository>();
builder.Services.AddScoped<IPagosRepository, PagosRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuarioRepository>();

//Servicios
builder.Services.AddScoped<IPacientesServices, PacienteService>();
builder.Services.AddScoped<IConsultasServices, ConsultasServices>();
builder.Services.AddScoped<IDiagnosticosServices, DiagnosticosServices>();
builder.Services.AddScoped<ITratamientosServices, TratamientosServices>();
builder.Services.AddScoped<IMedicosServices, MedicoService>();
builder.Services.AddScoped<IPagosServices, PagosServices>();
builder.Services.AddScoped<IUsuariosServices, UsuarioServices>();



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
