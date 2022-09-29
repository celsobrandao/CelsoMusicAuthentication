using CelsoMusicAuthentication.Domain.Usuario.Repository;
using CelsoMusicAuthentication.Repository.Context;
using CelsoMusicAuthentication.Repository.Database;
using CelsoMusicAuthentication.Repository.Repository.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CelsoMusicAuthentication.Repository
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CelsoMusicAuthenticationContext>(c =>
            {
                c.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(Repository<>));

            #region Usuario
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            #endregion

            return services;
        }
    }
}
