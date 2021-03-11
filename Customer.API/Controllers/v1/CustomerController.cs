using Customer.API.Contracts;
using Customer.API.ViewModel;
using CustomerService.API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Customer.API.Controllers
{
    //[Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IConfiguration _configuration;

        public CustomerController(ICustomerService customerService, IConfiguration configuration)
        {
            _customerService = customerService;
            _configuration = configuration;
        }

        [HttpPost(ApiRoutes.Customer.Add)]
        public async Task<IActionResult> Add(CustomerViewModel customer)
        {
            return Ok(await _customerService.Add(customer));
        }
        
        [HttpPut(ApiRoutes.Customer.Update)]
        public async Task<IActionResult> Update(CustomerViewModel customer)
        {
            return Ok(await _customerService.Update(customer));
        }

        [HttpGet(ApiRoutes.Customer.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetCustomers());
        }
        
        [HttpGet(ApiRoutes.Customer.GetById)]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await _customerService.GetById(id));
        }
        [HttpDelete(ApiRoutes.Customer.RemoveById)]
        public async Task<IActionResult> RemoveById(long id)
        {
            return Ok(await _customerService.RemoveById(id));
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            var conn = _configuration["ConnectionStrings:CustomerDBConnection"];
            return Ok(new { conn });
        }

    }
}
