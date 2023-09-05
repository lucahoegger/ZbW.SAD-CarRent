namespace Zbw.Carrent.ReservationManagement.Domain;

public interface IReservationRepository
{
    IEnumerable<Reservation> GetAll();
    Reservation? Get(Guid id);
    Reservation Add(Reservation reservation);
    void Remove(Guid id);
    Reservation Update(Reservation reservation);
}