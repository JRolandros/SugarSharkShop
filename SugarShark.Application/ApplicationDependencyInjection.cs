using Microsoft.Extensions.DependencyInjection;
using SugarShark.Application.CartModule;
using SugarShark.Application.CatalogModule;
using SugarShark.Application.OrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); 
            services.AddMediatR(config=>config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddCatalogModule();
            services.AddCartModule();
            services.AddOrderModule();

            return services;
        }
    }
}
