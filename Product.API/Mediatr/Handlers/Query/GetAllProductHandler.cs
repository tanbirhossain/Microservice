using Mapster;
using MediatR;
using Product.API.Mediatr.Requests.Command;
using Product.API.Mediatr.Requests.Query;
using Product.API.Mediatr.Responses.Query;
using Product.API.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Product.API.Mediatr.Handlers.Query
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, List<GetAllProductResponse>>
    {
        private readonly IProductRepository _productReposotory;

        public GetAllProductHandler(IProductRepository productReposotory)
        {
            _productReposotory = productReposotory;
        }

        public async Task<List<GetAllProductResponse>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var result = await _productReposotory.GetAllProdcutAsync();
            return result.Adapt<List<GetAllProductResponse>>();
        }
    }
}
