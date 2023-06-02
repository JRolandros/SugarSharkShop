using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SugarShark.Application.CartModule.Repositories;
using SugarShark.Application.CatalogModule.Repositories;
using SugarShark.Application.Common;
using SugarShark.Application.OrderModule.Repositories;
using SugarShark.Infrastructure.CartModule.Repertories;
using SugarShark.Infrastructure.CatalogModule.Repositories;
using SugarShark.Infrastructure.OrderModule.Repertories;

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
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}