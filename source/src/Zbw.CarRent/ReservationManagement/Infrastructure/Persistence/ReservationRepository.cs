using Microsoft.EntityFrameworkCore;
using Zbw.Carrent.CrossCutting.Infrastructure.Persistence;
using Zbw.Carrent.ReservationManagement.Domain;

namespace Zbw.Carrent.ReservationManagement.Infrastructure.Persistence;

public class ReservationRepository : IReservationRepository
{
    private readonly CarRentContext _context;

    public ReservationRepository(CarRentContext context)
    {
        _context = context;
    }

    public IEnumerable<Reservation> GetAll()
    {
        return _context.Reservations
            .Include(f => f.Customer)
            .Include(f => f.Car)
            .ToList();
    }

    public Reservation? Get(Guid id)
    {
        return _context.Reservations
            .Include(f => f.Customer)
            .Include(f => f.Car)
            .FirstOrDefault(f => f.Id == id);
    }

    public Reservation Add(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        _context.SaveChanges();
        return reservation;
    }

    public void Remove(Guid id)
    {
        var reservationToDelete = _context.Reservations.Find(id);
        if (reservationToDelete == null) return;
        _context.Reservations.Remove(reservationToDelete);
        _context.SaveChanges();
    }

    public Reservation Update(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
        _context.SaveChanges();
        return reservation;
    }
}