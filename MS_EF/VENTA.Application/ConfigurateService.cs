using Microsoft.Extensions.DependencyInjection;
using MS_EF.Application.Interface;
using MS_EF.Application.service;
using MS_EF.Persistence.EFCore;

namespace VENTA.Application
{
    public static class ConfigurateService
    {
        public static IServiceCollection ConfigurarAplicacion(this IServiceCollection services)
        {
            services.ConfigurationPersistenceEFCore();
            services.AddTransient<IFormService, FormService>();
            services.AddTransient<IInputService, InputService>();

            return services;
        }
    }
}
