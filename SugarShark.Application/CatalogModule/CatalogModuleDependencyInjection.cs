using Microsoft.Extensions.DependencyInjection;
using SugarShark.Application.CatalogModule.Services;

namespace SugarShark.Application.CatalogModule
{
    internal static class CatalogModuleDependencyInjection
    {
        internal static IServiceCollection AddCatalogModule(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly()); //Will be used once in the current assembly
            //services.AddMediatR(config=>config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); //Will be used once in the current assembly

            services.AddScoped<ICatalogService, CatalogService>();
            return services;
        } 
    }
}
