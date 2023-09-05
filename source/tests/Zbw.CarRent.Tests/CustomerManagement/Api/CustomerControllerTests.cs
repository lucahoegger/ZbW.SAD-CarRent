using DeepEqual.Syntax;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Zbw.Carrent.CustomerManagement.Api.Models;
using Zbw.Carrent.CustomerManagement.Domain;

namespace Zbw.Carrent.Tests.CustomerManagement.Api
{
    using System;
    using System.Collections.Generic;

    using FluentAssertions;

    using Zbw.Carrent.CustomerManagement.Api;

    public class CustomerControllerTests
    {
        [Fact]
        public void Create_WhenNoRepository_ThenThrow()
        {
            Action act = () => new CustomerController(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Get_ShouldReturn_AllCustomers()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            Mock<ICustomerRepository> mockICustomerRepo = new Mock<ICustomerRepository>(MockBehavior.Strict);
            mockICustomerRepo.Setup(f => f.GetAll()).Returns(new List<Customer>{new Customer
            {
                Id = customerId,
                CustomerNr = 1,
                Address = "Meisenweg 1",
                FirstName = "Fritz",
                LastName = "Muster"
            }});
            
            var customerController = new CustomerController(mockICustomerRepo.Object);
            
            // Act
            var result = (customerController.Get()) as OkObjectResult;
            
            // Assert
            result.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(new List<CustomerResponse>
                { new CustomerResponse(customerId, 1, "Fritz", "Muster", "Meisenweg 1") });
        }

        [Fact]
        public void Get_ShouldReturn_Customer()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            Mock<ICustomerRepository> mockICustomerRepo = new Mock<ICustomerRepository>(MockBehavior.Strict);
            mockICustomerRepo.Setup(f => f.Get(customerId)).Returns(new Customer
            {
                Id = customerId,
                CustomerNr = 1,
                Address = "Altgasse 12",
                FirstName = "Hans",
                LastName = "Peter"
            });
            
            var customerController = new CustomerController(mockICustomerRepo.Object);
            
            // Act
            var result = (customerController.Get(customerId)) as OkObjectResult;
            
            // Assert
            
            result.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(new CustomerResponse(customerId, 1, "Hans", "Peter", "Altgasse 12"));
        }


        [Fact]
        public void Post_Should_CreateCustomer()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            Mock<ICustomerRepository> mockICustomerRepo = new Mock<ICustomerRepository>(MockBehavior.Strict);
            var customerRequest = new CustomerCreateRequest(customerId, 1,"Lorem", "Ipsum", "Multerweg 12");
            var newCustomer = new Customer
            {
                Id = customerId,
                CustomerNr = 1,
                Address = "Multerweg 12",
                FirstName = "Lorem",
                LastName = "Ipsum"
            };
            mockICustomerRepo.Setup(f => f.Add(It.Is<Customer>(g => g.WithDeepEqual(newCustomer).Compare())))
                .Returns(newCustomer);
            
            var customerController = new CustomerController(mockICustomerRepo.Object);
            
            // Act
            var result = customerController.Post(customerRequest);

            // Assert
            result.Should().BeEquivalentTo(new CustomerResponse(customerId, 1, "Lorem", "Ipsum", "Multerweg 12"));

        }
    }
}
