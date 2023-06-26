using Microsoft.AspNetCore.Mvc;
using Zbw.CarRent.CustomerManagement.Domain;

namespace Zbw.CarRent.CustomerManagement.Api.Models
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public IEnumerable<CustomerResponse> Get()
        {
            var customers = _customerRepository.GetAll();
            return customers.Select(x => new CustomerResponse(x.Id, x.CustomerNr, x.FirstName, x.LastName, x.Address));
        }
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<CustomerResponse> Get(Guid id)
        {
            var customer = _customerRepository.Get(id);
            if (customer != null)
            {
                return  Ok(new CustomerResponse(customer.Id, customer.CustomerNr, customer.FirstName, customer.LastName, customer.Address));
            }

            return NotFound();
        }

        // POST: api/api
        [HttpPost]
        public ActionResult<CustomerResponse> Post([FromBody] CustomerRequest value)
        {
            return Ok(value);
        }

        // PUT: api/api/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CustomerRequest value)
        {
        }

        // DELETE: api/api/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
