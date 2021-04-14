using Mapster;
using MediatR;
using Product.API.Mediatr.Requests.Query;
using Product.API.Mediatr.Responses.Query;
using Product.API.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Product.API.Mediatr.Handlers.Query
{
    public class GetByIdProductHandler : IRequestHandler<GetByIdProductRequest, GetByIdProductResponse>
    {
        private readonly IProductRepository _productReposotory;

        public GetByIdProductHandler(IProductRepository productReposotory)
        {
            _productReposotory = productReposotory;
        }

        public async Task<GetByIdProductResponse> Handle(GetByIdProductRequest request, CancellationToken cancellationToken)
        {
            var result = await _productReposotory.GetProductByIdAsync(request.Id);
            return result.Adapt<GetByIdProductResponse>();
        }
    }
}
