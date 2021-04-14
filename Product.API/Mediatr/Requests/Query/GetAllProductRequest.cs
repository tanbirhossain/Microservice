using MediatR;
using Product.API.Mediatr.Responses.Query;
using System.Collections.Generic;

namespace Product.API.Mediatr.Requests.Query
{
    public class GetAllProductRequest : IRequest<List<GetAllProductResponse>>
    {
        public long Id { get; set; }
    }
}
