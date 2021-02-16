using Customer.API.Mapper;
using CustomerService.API.Repository;
using CustomerService.API.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Customer.API.Database;
using Microsoft.EntityFrameworkCore;
using Customer.API.Repository;
using Customer.API.Services;

namespace CustomerService.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // IOC
            services.AddTransient<ICustomerService, CustomerService.API.Service.CustomerService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ISeedRepository, CustomerDBSeedRepository>();
            services.AddTransient<ISeedService, CustomerSeedService>();

            // Config           
            var _customerConnection = Configuration.GetConnectionString("CustomerDBConnection");
            services.AddDbContext<CustomerDBContext>(option =>
                option.UseSqlServer(_customerConnection)
            );
         
            // Automapper
            services.AddAutoMapper(typeof(AutomapperProfile).Assembly);

            // seed
            var serviceProvider = services.BuildServiceProvider();
            if (serviceProvider != null)
            {
                var _customerRepository = serviceProvider.GetService<ISeedService>();
                _customerRepository.DoSeed();
            }

            // open api
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
