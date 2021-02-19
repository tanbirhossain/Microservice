
using Customer.API.RequestModels.CommandRequestModels;
using Customer.API.RequestModels.QueryRequestModels;
using CustomerService.API.Service;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
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
