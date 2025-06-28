
using FarmaciaTalentoTech.Model.Interfaces;
using FarmaciaTalentoTech.RepositoryEF;
using FarmaciaTalentoTech.RepositoryEF.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FarmaciaTalentoTech.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //builder.Services.AddScoped<IFarmaciaTalentoTechDB, FarmaciaTalentoTechDB>();
        builder.Services.AddDbContext<FarmaciaTalentoTechContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("FarmaciaTalentoTechDBConnection")));

        builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        builder.Services.AddScoped<IRolesRepositorio, RolRepositorio>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
