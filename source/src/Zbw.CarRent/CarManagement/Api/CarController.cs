using Microsoft.AspNetCore.Mvc;
using Zbw.Carrent.CarManagement.Infrastructure.Persistence;
using Zbw.Carrent.CustomerManagement.Api.Models;
using Zbw.Carrent.CustomerManagement.Domain;

namespace Zbw.Carrent.CarManagement.Api
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _repository;

        public CarController(ICarRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository);

            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cars = _repository.GetAll();
            var carResponses = cars.Select(MapToResponse);
            return Ok(carResponses);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var car = _repository.Get(id);
            if (car != null)
            {
                return Ok(MapToResponse(car));
            }

            return NotFound();
        }

        [HttpPost]
        public CarResponse Post([FromBody] CarCreateRequest value)
        {
            var newCar = new Car
            {
                Id = Guid.NewGuid(),
                IdentificationNr = value.IdentificationNr,
                Brand = value.Brand,
                Class = value.CarClass
                
            };
            var addedCar = _repository.Add(newCar);
            return MapToResponse(addedCar);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] CarRequest value)
        {
            var car = _repository.Get(id);
            if (car == null) return NotFound();
            car.IdentificationNr = value.IdentificationNr;
            car.Brand = value.Brand;
            car.Class = value.CarClass;
            var updatedCar = _repository.Update(car);
            return Ok(MapToResponse(updatedCar));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var car = _repository.Get(id);
            if (car == null) return NotFound();
            _repository.Remove(car.Id);
            return Ok();
        }
        
        private CarResponse MapToResponse(Car car)
        {
            return new CarResponse(car.Id,car.IdentificationNr, car.Brand, car.Class);
        }
    }
}