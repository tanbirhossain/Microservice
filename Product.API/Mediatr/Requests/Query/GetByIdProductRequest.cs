using MediatR;
using Product.API.Mediatr.Responses.Query;

namespace Product.API.Mediatr.Requests.Query
{
    public class GetByIdProductRequest : IRequest<GetByIdProductResponse>
    {
        public long Id { get; set; }
    }
}
