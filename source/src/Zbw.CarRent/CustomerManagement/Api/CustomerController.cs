namespace Zbw.Carrent.CustomerManagement.Api
{
    using Microsoft.AspNetCore.Mvc;
    using Zbw.Carrent.CustomerManagement.Api.Models;
    using Zbw.Carrent.CustomerManagement.Domain;

    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository);

            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var allCustomers = _repository.GetAll();
            var customerResponses = allCustomers.Select(MapToResponse);
            return Ok(customerResponses);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var customer = _repository.Get(id);
            if (customer != null)
            {
                return Ok(MapToResponse(customer));
            }

            return NotFound();
        }

        [HttpPost]
        public CustomerResponse Post([FromBody] CustomerCreateRequest value)
        {
            var newCustomer = new Customer
            {
                Id = value.Id,
                CustomerNr = value.CustomerNr,
                FirstName = value.Firstname,
                LastName = value.Lastname,
                Address = value.Address
            };
            var addedCustomer = _repository.Add(newCustomer);
            return MapToResponse(addedCustomer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] CustomerRequest value)
        {
            var customer = _repository.Get(id);
            if (customer == null) return NotFound();
            customer.FirstName = value.Firstname;
            customer.LastName = value.Lastname;
            customer.Address = value.Address;
            var updatedCustomer = _repository.Update(customer);
            return Ok(MapToResponse(updatedCustomer));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var customer = _repository.Get(id);
            if (customer == null) return NotFound();
            _repository.Remove(customer.Id);
            return Ok();
        }
        
        private CustomerResponse MapToResponse(Customer customer)
        {
            return new CustomerResponse(customer.Id, customer.CustomerNr, customer.FirstName, customer.LastName,
                customer.Address);
        }
    }
}