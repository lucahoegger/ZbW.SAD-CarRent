using Zbw.Carrent.CarManagement.Infrastructure.Persistence;

namespace Zbw.Carrent.CarManagement;

public record CarRequest(
    Guid Id,
    string IdentificationNr,
    CarBrand Brand,
    CarClass CarClass
    );