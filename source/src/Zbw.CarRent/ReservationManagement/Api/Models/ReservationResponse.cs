namespace Zbw.Carrent.ReservationManagement.Api.Models;

public record ReservationResponse(
    Guid Id,
    int AmountOfDays,
    decimal TotalCosts,
    Guid CarId,
    Guid CustomerId
);