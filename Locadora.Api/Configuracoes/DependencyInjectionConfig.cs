using Locadora.Domain.Handlers;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Infra.Data.DataContexts;
using Locadora.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.Api.Configuracoes
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            #region DataContexts

            services.AddScoped<DataContext>();

            #endregion

            #region Repositories

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IVotoRepository, VotoRepository>();

            #endregion

            #region Handlers

            services.AddScoped<UsuarioHandler>();
            services.AddScoped<FilmeHandler>();
            services.AddScoped<VotoHandler>();
            services.AddScoped<AutenticacaoHandler>();

            #endregion

            return services;
        }
    }
}
