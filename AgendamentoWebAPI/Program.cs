using System.Text;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Repository;
using AgendamentoWebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AgendamentoWebAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                        "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                        "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
services.AddCors();

services.AddTransient(x => new MySqlConnection(builder.Configuration.GetConnectionString("AWS")));
services.AddScoped<IEspecialidadesService, EspecialidadesService>();
services.AddScoped<IEspecialidadesDatabase, EspecialidadesDatabase>();
services.AddScoped<IMedicoService, MedicoService>();
services.AddScoped<IMedicoDatabase, MedicoDatabase>();
services.AddScoped<IDataHoraAgendamentoDatabase, DataHoraAgendamentoDatabase>();
services.AddScoped<IDataHoraAgendamentoService, DataHoraAgendamentoService>();
services.AddScoped<ITipoConsultaService, TipoConsultaService>();
services.AddScoped<ITipoConsultaDatabase, TipoConsultaDatabase>();
services.AddScoped<IAgendamentoService, AgendamentoService>();
services.AddScoped<IAgendamentoDatabase, AgendamentoDatabase>();

var key = Encoding.ASCII.GetBytes(Settings.Secret);
    services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(options => {options.AllowAnyOrigin(); options.AllowAnyHeader(); options.AllowAnyMethod();});

app.MapControllers();

app.Run();
