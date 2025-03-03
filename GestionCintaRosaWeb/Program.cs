using System.Text;
using CapaDatos;
using CapaDatos.Interfaces;
using CapaDatos.Repositorios;
using CapaLogica.DTO;
using CapaLogica.Interfaces;
using CapaLogica.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Aqui configuramos el jason web token para que podamos dar un toque a la sesi�n.


JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

var key = Encoding.ASCII.GetBytes(builder.Configuration["JWT:key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateLifetime = true
    };
     options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.ContainsKey("auth_token"))
            {
                context.Token = context.Request.Cookies["auth_token"];
            }
            return Task.CompletedTask;
        }
   };
});

var corsPolicy = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});



builder.Services.AddAuthorization();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JWT"));


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
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IValidateToken, ValidateToken>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("_myAllowSpecificOrigins");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
