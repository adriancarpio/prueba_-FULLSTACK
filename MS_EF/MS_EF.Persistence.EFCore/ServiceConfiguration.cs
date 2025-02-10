using Microsoft.Extensions.DependencyInjection;
using MS_EF.Domain.Interface;
using MS_EF.Persistence.EFCore.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_EF.Persistence.EFCore
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigurationPersistenceEFCore(this IServiceCollection services)
        {
            services.AddTransient<IFormRepository, FormRepository>();
            services.AddTransient<IInputRepository, InputRepository>();
            return services;
        }
    }
}
