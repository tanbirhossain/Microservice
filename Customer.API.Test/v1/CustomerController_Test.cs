using AutoMapper;
using Customer.API.Controllers;
using Customer.API.Database;
using Customer.API.Mapper;
using Customer.API.Services;
using Customer.API.ViewModel;
using CustomerService.API.Repository;
using CustomerService.API.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Customer.API.Test.v1
{
    public class CustomerController_Test
    {
        private readonly IMapper _mapper;
        private Mock<ILoggingService> _loggerMock;
        private Mock<ICustomerRepository> _customerRepoMock;
        public CustomerController_Test()
        {
            // auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomapperProfile());
            });
            _mapper = mockMapper.CreateMapper();
            _loggerMock = new Mock<ILoggingService>();
            _customerRepoMock = new Mock<ICustomerRepository>();
        }

        [Fact]
        public async Task GetAllCusotmer_testAsync()
        {
            // arrange

            // mock data
            var customerMockData = new tbl_Customer
            {
                Id = 2,
                Name = "Kashem",
                DOB = null
            };
            _customerRepoMock.Setup(e => e.GetById(2)).ReturnsAsync(customerMockData);


            ICustomerService _customerSevice = new CustomerService.API.Service.CustomerService(_loggerMock.Object, _mapper, _customerRepoMock.Object);
            var controller = new CustomerController(_customerSevice);


            // Act
            var result = await controller.GetById(2);

            // Assert
            var okResult = result as OkObjectResult;
            if (okResult != null)
                Assert.NotNull(okResult);

            var customerVM = okResult.Value as CustomerViewModel;
            var expected = customerMockData.Name;
            var actual = customerVM.Name;
            Assert.Equal(expected, actual);
        }

    }
}

