using Customer.API.RequestModels.QueryRequestModels;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Customer.API.Test.v1
{
   public class CustomerController_Test
    {
        private Mock<IMediator> _mediator;
        public CustomerController_Test()
        {
            _mediator = new Mock<IMediator>();
        }

        //[Fact]
        //public void GetAllCustomers_Test()
        //{
        //    var request = new GetAllCustomersRequestModel();
        //    _mediator.Setup(x => x.Send(It.IsAny<GetAllCustomersRequestModel>(), new System.Threading.CancellationToken()))
        //        .ReturnsAsync(new );
        //}
    }
}
