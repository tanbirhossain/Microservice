using Customer.API.Database;
using CustomerService.API;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace CustomerAPI.Intigration.Test
{
    public class IntegrationTest
    {
        protected readonly HttpClient _testClient;
        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {


                        //        var descriptor = services.SingleOrDefault(
                        //d => d.ServiceType ==
                        //    typeof(DbContextOptions<CustomerDBContext>));

                        //        services.Remove(descriptor);

                        services.AddDbContext<CustomerDBContext>(options =>
                        {
                            options.UseInMemoryDatabase("InMemoryDbForTesting");
                        });

                        //var sp = services.BuildServiceProvider();

                        //using (var scope = sp.CreateScope())
                        //{
                        //    var scopedServices = scope.ServiceProvider;
                        //    var db = scopedServices.GetRequiredService<CustomerDBContext>();
                        //    //var logger = scopedServices
                        //    //    .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();
                        //    var _seedRepository = scopedServices.GetRequiredService<ISeedRepository>();
                        //    //db.Database.EnsureCreated();

                        //    try
                        //    {
                        //        _seedRepository.DoSeed();
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        Console.WriteLine(ex.Message);
                        //    }
                        //}

                    });
                });
            _testClient = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
            _testClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }
        private async Task<string> GetJwtAsync()
        {
            //var response = await _testClient.PostAsJsonAsync(ApiRoutes.Identity.Register, new UserRegistrationRequest
            //{
            //    Email = "test@integration.com",
            //    Password = "SomePass1234!"
            //});

            //var registrationResponse = await response.Content.ReadAsAsync<AuthSuccessResponse>();
            //return registrationResponse.Token;
            return "";
        }
    }
}
