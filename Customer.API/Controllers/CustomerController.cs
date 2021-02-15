using CustomerService.API.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _customerService.GetCustomers());
        }
    }
}
