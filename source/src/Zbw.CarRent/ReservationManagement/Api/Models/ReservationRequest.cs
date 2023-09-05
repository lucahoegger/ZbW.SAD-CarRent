using Zbw.Carrent.CarManagement.Infrastructure.Persistence;
using Zbw.Carrent.CustomerManagement.Domain;

namespace Zbw.Carrent.ReservationManagement.Api.Models;

public record ReservationRequest(
    Guid Id,
    int AmountOfDays,
    decimal TotalCosts,
    Car Car,
    Customer Customer
);