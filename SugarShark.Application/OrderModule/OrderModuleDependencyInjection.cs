using Microsoft.Extensions.DependencyInjection;
using SugarShark.Application.OrderModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.OrderModule
{
    internal static class OrderModuleDependencyInjection
    {
        internal static IServiceCollection AddOrderModule(this IServiceCollection services)
        {
            services.AddScoped<IOrderService,OrderService>();

            return services;
        }
    }
}
