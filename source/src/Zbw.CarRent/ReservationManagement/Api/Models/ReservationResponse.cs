using Zbw.Carrent.CarManagement;
using Zbw.Carrent.CustomerManagement.Api.Models;

namespace Zbw.Carrent.ReservationManagement.Api.Models;

public record ReservationResponse(
        Guid Id,
        int AmountOfDays,
        decimal TotalCosts,
        CarResponse Car,
        CustomerResponse Customer
    );