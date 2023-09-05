using Zbw.Carrent.CarManagement.Infrastructure.Persistence;
using Zbw.Carrent.CustomerManagement.Domain;

namespace Zbw.Carrent.ReservationManagement.Domain;

public class Reservation
{
    public Guid Id { get; set; }
    public int AmountOfDays { get; set; }
    public decimal TotalCosts { get; set; }
    public Guid CarId { get; set; }
    public Car Car { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
}