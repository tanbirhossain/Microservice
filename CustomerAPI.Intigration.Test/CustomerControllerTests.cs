using Customer.API.Contracts;
using Customer.API.ViewModel;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CustomerAPI.Intigration.Test
{
    public class CustomerControllerTests : IntegrationTest
    {

        [Fact]
        public async Task GetAll_WithoutAnyCustomer_ReturnEmptyResponse()
        {
            // Arrange
            //await AuthenticateAsync();


            // Act
            var response = await _testClient.GetAsync(ApiRoutes.Customer.GetAll);
            var returnedPost = await response.Content.ReadAsAsync<List<CustomerViewModel>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        } 
        [Theory]
        [InlineData(7)]
        public async Task GetCustomer_InputId_ReturnSingleCustomerResponse(long id)
        {
            // Arrange
            //await AuthenticateAsync();


            // Act
            var response = await _testClient.GetAsync(ApiRoutes.Customer.GetById.Replace("{id}",id.ToString()));
            var singleCustomer = await response.Content.ReadAsAsync<CustomerViewModel>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task Get_ReturnCustomer_WhenCustomerPostInDatabase()
        {
            // Arrange
            //await AuthenticateAsync();
            var customerReq = new CustomerViewModel { Name = "testName" };

            // Act
            var response = await _testClient.PostAsJsonAsync(ApiRoutes.Customer.Add, customerReq);
            var add_Customer_response = await response.Content.ReadAsAsync<CustomerViewModel>();

            var result = await _testClient.GetAsync(ApiRoutes.Customer.GetById.Replace("{id}", add_Customer_response.Id.ToString()));
            var singleCustomer = await result.Content.ReadAsAsync<CustomerViewModel>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            add_Customer_response.Id.Should().Be(singleCustomer.Id);

        }
    }
}
