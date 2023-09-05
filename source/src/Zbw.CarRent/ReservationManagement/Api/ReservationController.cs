using Microsoft.AspNetCore.Mvc;
using Zbw.Carrent.ReservationManagement.Api.Models;
using Zbw.Carrent.ReservationManagement.Domain;

namespace Zbw.Carrent.ReservationManagement.Api;

[Route("api/reservations")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IReservationRepository _repository;
    public ReservationController(IReservationRepository repository)
    {
        ArgumentNullException.ThrowIfNull(repository);
        _repository = repository;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var allReservations = _repository.GetAll();
        var reservationResponses = allReservations.Select(MapToResponse);
        return Ok(reservationResponses);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var reservation = _repository.Get(id);
        if (reservation != null)
        {
            return Ok(MapToResponse(reservation));
        }
        return NotFound();
    }
    
    [HttpPost]
    public ReservationResponse Post([FromBody] ReservationCreateRequest value)
    {
        var newReservation = new Reservation
        {
            Id = Guid.NewGuid(),
            AmountOfDays = value.AmountOfDays,
            TotalCosts = value.TotalCosts,
            CarId = value.CarId,
            CustomerId = value.CustomerId
        };
        var addedReservation = _repository.Add(newReservation);
        return MapToResponse(addedReservation);
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] ReservationRequest value)
    {
        var reservation = _repository.Get(id);
        if (reservation == null) return NotFound();
        reservation.AmountOfDays = value.AmountOfDays;
        reservation.TotalCosts = value.TotalCosts;
        reservation.Car = value.Car;
        reservation.Customer = value.Customer;
        _repository.Update(reservation);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var reservation = _repository.Get(id);
        if (reservation == null) return NotFound();
        _repository.Remove(id);
        return Ok();
    }

    private ReservationResponse MapToResponse(Reservation reservation)
    {
        return new ReservationResponse(reservation.Id, reservation.AmountOfDays, reservation.TotalCosts, null, null);
    }

}