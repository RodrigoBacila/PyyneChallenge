using Application.Interfaces;
using BankAdapter.Adapter;
using Microsoft.Extensions.DependencyInjection;

namespace BankAdapter
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
        public static IServiceCollection AddBankSourceAdapter(this IServiceCollection services)
        {
            services.AddScoped<IBankSourceAdapter, BankSourceAdapter>();
            return services;
        }
    }
}
