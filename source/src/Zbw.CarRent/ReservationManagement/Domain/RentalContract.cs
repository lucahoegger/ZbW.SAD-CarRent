namespace Zbw.Carrent.ReservationManagement.Domain;

public class RentalContract
{
    public Guid Id { get; set; }

    public Guid ReservationId { get; set; }

    public Reservation Reservation { get; set; }

    public DateTime CreateDate { get; set; }
}