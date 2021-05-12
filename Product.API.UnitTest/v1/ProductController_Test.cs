using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Product.API.Controllers.v1;
using Product.API.Mediatr.Requests.Command;
using Product.API.Mediatr.Requests.Query;
using Product.API.Mediatr.Responses.Command;
using Product.API.Mediatr.Responses.Query;
using System.Threading.Tasks;
using Xunit;

namespace Product.API.UnitTest.v1
{
    public class ProductController_Test
    {
        private Mock<IMediator> _mediator;

        public ProductController_Test()
        {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task Product_Add_TestAsync()
        {
            // Arrange
            var productRequest = new AddProductRequest
            {
                Name = "ovi",
                Quantity = 0
            };
            var productMockResult = new AddProductResponse
            {
                Id = 9,
                Name = "ovi",
                Quantity = 5
            };  
            
         
            _mediator.Setup(x => x.Send(It.IsAny<AddProductRequest>(), new System.Threading.CancellationToken()))
                    .ReturnsAsync(productMockResult);

            var controller = new ProductController(_mediator.Object);
            // Act
            var result = await controller.Add(productRequest);
            var okResult = result as OkObjectResult;

            // Assert
            if (okResult != null)
            {
                Assert.NotNull(okResult);
            }
            var response = okResult.Value as AddProductResponse;
            Assert.Equal("ovi", response.Name);
        }

        [Fact]
        public async Task Product_GetById_TestAsync()
        {
            // Arrange
            var testId = 1;
            var productMockResult = new GetByIdProductResponse
            {
                Id = 1,
                Name = "ovi"
            };
            _mediator.Setup(x => x.Send(It.IsAny<GetByIdProductRequest>(), new System.Threading.CancellationToken()))
                    .ReturnsAsync(productMockResult);

            var controller = new ProductController(_mediator.Object);
            // Act
            var result = await controller.GetById(testId);
            var okResult = result as OkObjectResult;

            // Assert
            if (okResult != null)
            {
                Assert.NotNull(okResult);
            } 
            var response = okResult.Value as GetByIdProductResponse;
            Assert.Equal("ovi", response.Name);
        }
    }
}

