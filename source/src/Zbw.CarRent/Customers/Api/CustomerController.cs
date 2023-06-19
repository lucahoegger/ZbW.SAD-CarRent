using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Zbw.CarRent.Api
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/api
        [HttpGet]
        public IEnumerable<CustomerResponse> Get()
        {
            return new CustomerResponse[]
            {
                new CustomerResponse { Id = Guid.NewGuid(), CustomerNr = "1", FirstName = "Luca", LastName = "Högger"},
                new CustomerResponse { Id = Guid.NewGuid(), CustomerNr = "2", FirstName = "Dominik", LastName = "Hauser"},
            };
        }

        // GET: api/api/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            return Ok("ok");
        }

        // POST: api/api
        [HttpPost]
        public ActionResult<CustomerRequest> Post([FromBody] CustomerRequest value)
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
