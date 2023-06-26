namespace Zbw.CarRent.CustomerManagement.Domain;

public interface ICustomerRepository
{
    IEnumerable<Customer> GetAll();

    Customer? Get(Guid id);

    Customer Add(Customer customer);
    
    void Remove(Guid id);
}