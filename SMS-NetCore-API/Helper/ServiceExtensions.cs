using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_NetCore_API.Helper
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses()
                .AsMatchingInterface()
                .WithScopedLifetime());

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //services.Scan(scan => scan
            //    .FromAssemblies(
            //        typeof(IBillingSitesRepository).Assembly
            //    )
            //    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository") || type.Name.EndsWith("UnitOfWork")))
            //    .AsMatchingInterface()
            //    .WithScopedLifetime());

            return services;
        }
    }
}
