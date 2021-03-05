using Customer.API.ViewModel;
using CustomerService.API.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Customer.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerViewModel customer)
        {
            return Ok(await _customerService.Add(customer));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetCustomers());
        }
        
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await _customerService.GetById(id));
        }
    }
}
