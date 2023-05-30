using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SugarShark.Application.CatalogModule.Repositories;
using SugarShark.Application.Common;
using SugarShark.Infrastructure.CatalogModule.Repositories;

namespace SugarShark.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SugarSharkDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SugarSharkConnection"),
                    builder => builder.MigrationsAssembly(typeof(SugarSharkDbContext).Assembly.FullName)));

            services.AddScoped<ISugarSharkDbContext>(provider => provider.GetRequiredService<SugarSharkDbContext>());

            services.AddScoped<IProductRepository,ProductRepository>();

            return services;
        }
    }
}