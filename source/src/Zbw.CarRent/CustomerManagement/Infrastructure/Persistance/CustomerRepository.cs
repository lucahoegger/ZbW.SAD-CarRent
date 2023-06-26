using Zbw.CarRent.CustomerManagement.Domain;

namespace Zbw.CarRent.CustomerManagement.Infrastructure.Persistance;

public class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers;

    public CustomerRepository()
    {
        _customers = new List<Customer>
        {
            new Customer { Id = Guid.NewGuid(), FirstName = "Peter", LastName = "Pan", CustomerNr = "1" },
            new Customer { Id = Guid.NewGuid(), FirstName = "Fritz", LastName = "Lobrecht", CustomerNr = "2" }
        };
    }
    public IEnumerable<Customer> GetAll()
    {
        return _customers;
    }

    public Customer? Get(Guid id)
    {
        return _customers.SingleOrDefault(c => c.Id == id);
    }

    public Customer Add(Customer customer)
    {
        _customers.Add(customer);
        return customer;
    }

    public void Remove(Guid id)
    {
        var customerToRemove = _customers.FirstOrDefault(c => c.Id == id);
        if (customerToRemove != null)
        {
            _customers.Remove(customerToRemove);
        }
    }
}