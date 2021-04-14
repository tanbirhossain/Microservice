using Mapster;
using MediatR;
using Product.API.Entities;
using Product.API.Mediatr.Requests.Command;
using Product.API.Mediatr.Responses.Command;
using Product.API.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Product.API.Mediatr.Handlers.Command
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<tbl_Product>(); 
            var result =  await _productRepository.UpdateProductAsync(product);
            return result.Adapt<UpdateProductResponse>();
        }
    }
}
