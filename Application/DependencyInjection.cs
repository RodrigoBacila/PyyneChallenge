using Application.BankingService;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    /// <summary>
    /// Dependency Injection
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Injects the relevant dependencies in the project
        /// </summary>
        /// <param name="services">The application services collection</param>
        /// <returns>The application services collection with the injected dependencies</returns>
        public static IServiceCollection AddApplicationLogic(this IServiceCollection services)
        {
            services.AddScoped<IBankService, BankService>();
            return services;
        }
    }
}
