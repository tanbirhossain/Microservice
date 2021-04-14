using MediatR;
using Product.API.Mediatr.Responses.Command;

namespace Product.API.Mediatr.Requests.Command
{
    public class RemoveProductRequest : IRequest<RemoveProductResponse>
    {
        public long Id { get; set; }
    }
}
