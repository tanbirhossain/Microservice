using MediatR;
using Product.API.Mediatr.Responses.Command;

namespace Product.API.Mediatr.Requests.Command
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
    }  
}
