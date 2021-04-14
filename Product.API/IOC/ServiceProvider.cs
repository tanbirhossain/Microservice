using Microsoft.Extensions.DependencyInjection;
using Product.API.Entities;
using Product.API.Repositories;
using Product.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.IOC
{
    public static class ServiceProvider
    {
        public static void BuildIoc(this IServiceCollection services)
        {
            //// Service
            services.AddTransient<ILoggingService, LoggingService>();


            //// Repository
            services.AddTransient<IProductRepository, ProductRepository>();
            
            // cutomer handler
            //services.AddTransient<IAddCustomerCommandHandler, AddCustomerCommandHandler>();
            //services.AddTransient<IGetAllCustomerQueryHandler, GetAllCustomerQueryHandler>();

        }
    }
}
