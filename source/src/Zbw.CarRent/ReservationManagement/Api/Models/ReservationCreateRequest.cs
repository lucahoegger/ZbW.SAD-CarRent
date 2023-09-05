using Zbw.Carrent.CarManagement.Infrastructure.Persistence;
using Zbw.Carrent.CustomerManagement.Domain;

namespace Zbw.Carrent.ReservationManagement.Api.Models;

public record ReservationCreateRequest(
        Guid Id,
        int AmountOfDays,
        decimal TotalCosts,
        Guid CarId,
        Guid CustomerId
    );