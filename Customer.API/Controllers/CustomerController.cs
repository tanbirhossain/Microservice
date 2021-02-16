using Customer.API.ViewModel;
using CustomerService.API.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerService.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
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
        [HttpGet]
        public async Task<IActionResult> RemoveById(long id)
        {
            return Ok(await _customerService.RemoveById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(CustomerViewModel customer)
        {
            return Ok(await _customerService.Add(customer));
        }
        [HttpPost]
        public async Task<IActionResult> Update(CustomerViewModel customer)
        {
            return Ok(await _customerService.Update(customer));
        }
    }
}
