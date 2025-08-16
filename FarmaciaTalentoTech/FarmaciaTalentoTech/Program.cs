
using FarmaciaTalentoTech.Model.Interfaces;
using FarmaciaTalentoTech.RepositoryEF;
using FarmaciaTalentoTech.RepositoryEF.DataBaseContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace FarmaciaTalentoTech.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(opciones =>
        {
            opciones.AddPolicy("PermitirTodo", politica => {
                politica.AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyHeader();
            });
        });

        // Add services to the container.
        builder.Services.AddControllers();
        //builder.Services.AddScoped<IFarmaciaTalentoTechDB, FarmaciaTalentoTechDB>();
        builder.Services.AddDbContext<FarmaciaTalentoTechContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("FarmaciaTalentoTechDBConnection"))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging());

        builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        builder.Services.AddScoped<IRolesRepositorio, RolRepositorio>();
        builder.Services.AddScoped<IPermisoRepositorio, PermisoRepositorio>();
        // JWT Authentication configuration
        var jwtKey = builder.Configuration["Jwt:Key"];
        var jwtIssuer = builder.Configuration["Jwt:Issuer"];


        builder.Services.AddAuthentication(opciones =>
        {
            opciones.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opciones.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(opciones => {
            opciones.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
            };
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opciones =>
        {
            opciones.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Introduzca 'Bearer' [espacio] y luego su token válido en la entrada de texto de abajo.\nEjemplo: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6...\""
            });

            opciones.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseCors("PermitirTodo");
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthentication();
        app.UseAuthorization();
        


        app.MapControllers();

        app.Run();
    }
}
