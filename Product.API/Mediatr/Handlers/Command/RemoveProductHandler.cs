using Mapster;
using MediatR;
using Product.API.Mediatr.Requests.Command;
using Product.API.Mediatr.Responses.Command;
using Product.API.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Product.API.Mediatr.Handlers.Command
{
    public class RemoveProductHandler : IRequestHandler<RemoveProductRequest, RemoveProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public RemoveProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<RemoveProductResponse> Handle(RemoveProductRequest request, CancellationToken cancellationToken)
        {
            var result =  await _productRepository.RemoveProductByIdAsync(request.Id);
            return result.Adapt<RemoveProductResponse>();
        }
    }
}
