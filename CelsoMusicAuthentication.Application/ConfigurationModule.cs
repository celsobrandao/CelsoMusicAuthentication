using CelsoMusicAuthentication.Application.Usuario.Service;
using CelsoMusicAuthentication.Application.Usuario.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CelsoMusicAuthentication.Application
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ConfigurationModule).Assembly);

            #region Usuario
            services.AddScoped<IUsuarioService, UsuarioService>();
            #endregion

            return services;
        }
    }
}
