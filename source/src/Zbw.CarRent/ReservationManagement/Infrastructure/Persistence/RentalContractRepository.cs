using Zbw.Carrent.CrossCutting.Infrastructure.Persistence;
using Zbw.Carrent.ReservationManagement.Domain;

namespace Zbw.Carrent.ReservationManagement.Infrastructure.Persistence;

public class RentalContractRepository : IRentalContractRepository
{
    private readonly CarRentContext _context;

    public RentalContractRepository(CarRentContext context)
    {
        _context = context;
    }

    public RentalContract Add(RentalContract rentalContract)
    {
        _context.RentalContracts.Add(rentalContract);
        _context.SaveChanges();
        return rentalContract;
    }
}