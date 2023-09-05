using Zbw.Carrent.CrossCutting.Infrastructure.Persistence;
using Zbw.Carrent.CustomerManagement.Domain;

namespace Zbw.Carrent.CustomerManagement.Infrastructure.Persistence;

public class CustomerRepository : ICustomerRepository
{
    private readonly CarRentContext _context;

    public CustomerRepository(CarRentContext context)
    {
        _context = context;
    }

    public Customer Add(Customer customer)
    {
        _context.Add(customer);
        _context.SaveChanges();
        return customer;
    }

    public Customer? Get(Guid id)
    {
        return _context.Customers.Find(id);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _context.Customers.ToList();
    }

    public Customer Update(Customer customer)
    {
        _context.Customers.Update(customer);
        _context.SaveChanges();
        return customer;
    }

    public void Remove(Guid id)
    {
        var customerToRemove = _context.Customers.Find(id);
        if (customerToRemove == null) return;
        _context.Customers.Remove(customerToRemove);
        _context.SaveChanges();
    }
}