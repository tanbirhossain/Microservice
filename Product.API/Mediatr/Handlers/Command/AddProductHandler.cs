using Mapster;
using MediatR;
using Product.API.Entities;
using Product.API.Mediatr.Requests.Command;
using Product.API.Mediatr.Responses.Command;
using Product.API.Repositories;
using Product.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Product.API.Mediatr.Handlers.Command
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILoggingService _logger;

        public AddProductHandler(IProductRepository productRepository, ILoggingService logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }
        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<tbl_Product>(); 
            var result =  await _productRepository.AddProductAsync(product);
            _logger.LogInformation($"Product Added. New Id : {result.Id}");
            return result.Adapt<AddProductResponse>();
        }
    }
}
