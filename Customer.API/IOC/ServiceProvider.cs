
using Customer.API.Repository;
using Customer.API.Services;
using CustomerService.API.Repository;
using CustomerService.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.API.IOC
{
    public static class ServiceProvider
    {
        public static void IOCBuild(this IServiceCollection services)
        {
            // Service
            services.AddTransient<ICustomerService, CustomerService.API.Service.CustomerService>();
            services.AddTransient<ISeedService, CustomerSeedService>();
            services.AddTransient<ILoggingService, LoggingService>();
            
            
            // Repository
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ISeedRepository, CustomerDBSeedRepository>();


            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();


            // cutomer handler
            //services.AddTransient<IAddCustomerCommandHandler, AddCustomerCommandHandler>();
            //services.AddTransient<IGetAllCustomerQueryHandler, GetAllCustomerQueryHandler>();

        }
    }
}
