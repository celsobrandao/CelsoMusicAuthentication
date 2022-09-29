using CelsoMusicAuthentication.API.Configuration;
using CelsoMusicAuthentication.Application;
using CelsoMusicAuthentication.Domain.Usuario.Repository;
using CelsoMusicAuthentication.Infra.Repository;
using CelsoMusicAuthentication.Repository;
using CelsoMusicAuthentication.Repository.Context;
using CelsoMusicAuthentication.Repository.Database;
using CelsoMusicAuthentication.Repository.Repository.Usuario;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureAuthentication(builder);

builder.Services.AddControllers();

builder.Services
    .RegisterApplication()
    .RegisterRepository(builder.Configuration.GetConnectionString("CelsoMusicAuthentication"));

builder.Services.AddDbContext<CelsoMusicAuthenticationContext>(c =>
{
    c.UseSqlServer(builder.Configuration.GetConnectionString("CelsoMusicAuthentication"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

#region Usuario
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
#endregion

builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
