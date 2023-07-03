using Moq;
using Zbw.CarRent.CustomerManagement.Api.Models;
using Zbw.CarRent.CustomerManagement.Domain;

namespace Zbw.CarRent;

public class CustomerControllerTests
{
    [Fact]
    public void Get_Should_Return_All_Customers()
    {
        Mock<ICustomerRepository> mockCustomerRepo = new Mock<ICustomerRepository>(MockBehavior.Strict);
        mockCustomerRepo.Setup(f => f.GetAll()).Returns(new List<Customer>());

        CustomerController controller = new CustomerController(mockCustomerRepo.Object);
        var result = controller.Get();
        Assert.Empty(result);
    }
}