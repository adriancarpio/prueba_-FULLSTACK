using Microsoft.Extensions.DependencyInjection;
using MS_EF.Persistence.EFCore;

namespace MS_EF.Infrastructure
{
    public static class ConfigurateServices
    {
        public static IServiceCollection ConfigurarInfraestructura(this IServiceCollection services)
        {
            services.ConfigurationPersistenceEFCore();
            return services;
        }

    }
}
