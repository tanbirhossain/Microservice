
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
            services.AddTransient<ICustomerService, CustomerService.API.Service.CustomerService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ISeedRepository, CustomerDBSeedRepository>();
            services.AddTransient<ISeedService, CustomerSeedService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            // cutomer handler
            //services.AddTransient<IAddCustomerCommandHandler, AddCustomerCommandHandler>();
            //services.AddTransient<IGetAllCustomerQueryHandler, GetAllCustomerQueryHandler>();

        }
    }
}
