namespace Zbw.Carrent.CustomerManagement.Domain
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer? Get(Guid id);
        Customer Add(Customer customer);
        void Remove(Guid id);
        Customer Update(Customer customer);
    }
}
