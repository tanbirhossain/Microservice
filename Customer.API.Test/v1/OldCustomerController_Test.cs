using Customer.API.Controllers;
using Customer.API.RequestModels.QueryRequestModels;
using Customer.API.ResponseModels.QueryResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Customer.API.Test.v1
{
    public class OldCustomerController_Test
    {
        private Mock<IMediator> _mediator;
        public OldCustomerController_Test()
        {
            _mediator = new Mock<IMediator>();
        }

        //[Fact]
        //public void GetAllCustomers_Test()
        //{
        //    var request = new GetAllCustomersRequestModel();

        //    _mediator.Setup(x => x.Send(It.IsAny<GetAllCustomersRequestModel>(), new System.Threading.CancellationToken()))
        //        .ReturnsAsync(new List<GetAllCustomersResponseModel> {
        //            new GetAllCustomersResponseModel { Name = "Test One"},
        //            new GetAllCustomersResponseModel { Name = "Test Two"}
        //        });

        //    var customerController = new OldCustomerController(_mediator.Object);

        //    // Action
        //    var result = customerController.GetAll();

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);

        //}
    }
}
