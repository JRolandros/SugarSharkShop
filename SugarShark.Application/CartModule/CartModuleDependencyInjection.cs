using Microsoft.Extensions.DependencyInjection;
using SugarShark.Application.CartModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CartModule
{
    internal static class CartModuleDependencyInjection
    {
        internal static IServiceCollection AddCartModule(this IServiceCollection services)
        {
            services.AddScoped<ICartService, CartService>();

            return services;
        }
    }
}
