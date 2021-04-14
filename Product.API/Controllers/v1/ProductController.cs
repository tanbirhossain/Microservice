using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.Mediatr.Requests.Command;
using Product.API.Mediatr.Requests.Query;
using System.Threading.Tasks;

namespace Product.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddProductRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            return Ok(await _mediator.Send(new RemoveProductRequest { Id = id}));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await _mediator.Send(new GetByIdProductRequest { Id = id }));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllProductRequest()));
        }


    }
}
