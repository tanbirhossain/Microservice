using AutoMapper;
using Customer.API.Controllers;
using Customer.API.Database;
using Customer.API.Mapper;
using Customer.API.ViewModel;
using CustomerService.API.Repository;
using CustomerService.API.Service;
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
    public class CustomerController_Test
    {
       private IMapper _mapper;
        public CustomerController_Test()
        {
            // auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomapperProfile());
            });
            _mapper = mockMapper.CreateMapper();
        }
        [Fact]
        public async Task GetAllCusotmer_testAsync()
        {
            // arrange

            // mock object
            var customerRepoMock = new Mock<ICustomerRepository>();
            // mock data
            var customerMockData = new tbl_Customer
            {
                Id = 2,
                Name = "Kashem",
                DOB = null
            };
            customerRepoMock.Setup(e => e.GetById(2)).ReturnsAsync(customerMockData);


            ICustomerService _customerSevice = new CustomerService.API.Service.CustomerService(_mapper, customerRepoMock.Object);
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
