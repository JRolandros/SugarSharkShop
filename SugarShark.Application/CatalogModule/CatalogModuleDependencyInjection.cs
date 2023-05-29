using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CatalogModule
{
    internal static class CatalogModuleDependencyInjection
    {
        static IServiceCollection AddCatalogModule(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly()); //Will be used once in the current assembly
            //services.AddMediatR(config=>config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); //Will be used once in the current assembly

            return services;
        } 
    }
}
