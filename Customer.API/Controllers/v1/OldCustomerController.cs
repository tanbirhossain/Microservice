using Customer.API.RequestModels.CommandRequestModels;
using Customer.API.RequestModels.QueryRequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Customer.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class OldCustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OldCustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerRequestModel customer)
        {
            return Ok(await _mediator.Send(customer));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllCustomersRequestModel();
            return Ok(await _mediator.Send(request));
        }
    }
}
