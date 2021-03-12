using Customer.API.Database;
using Customer.API.Repository;
using Customer.API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace CustomerService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}



//Install-Package Microsoft.EntityFrameworkCore.SqlServer
//Install-Package Microsoft.EntityFrameworkCore.Tools
//Install-Package Microsoft.EntityFrameworkCore.Design

////Scaffold-DbContext "Server=DESKTOP-1TP3BJN\MSSQLSERVER02;Database=ReservationDB;user id=sa;password=123456789;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DB -f -UseDatabaseNames
//Scaffold-DbContext "Server=localhost;Database=ReservationDB;user id=sa;password=123456789;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DB -f -UseDatabaseNames
//Scaffold-DbContext "Server=192.168.0.250,52149;Database=CustomerDB;user id=sa;password=123456789;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DBModel -f -UseDatabaseNames
