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
using Customer.API.IOC;
using System.Reflection;
using MediatR;
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

            // Register Mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // IOC
            services.IOCBuild();



            // Automapper
            services.AddAutoMapper(typeof(AutomapperProfile).Assembly);

            // open api
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer.API", Version = "v1" });
            });

            // Config               
            var _customerDBConnection = Configuration.GetConnectionString("CustomerDBConnection");
            services.AddDbContext<CustomerDBContext>(option =>
            {
                option.UseSqlServer(_customerDBConnection);
              
            });

            services.AddDbContext<CustomerDBContext>();
            services.AddDbContext<CustomerDBContext>(
      options => options.UseSqlServer(_customerDBConnection));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedService _seedService)
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


            // Ensure database
            _seedService.DoSeed();
        }
    }
}
