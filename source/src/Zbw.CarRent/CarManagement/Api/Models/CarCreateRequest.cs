using Zbw.Carrent.CarManagement.Infrastructure.Persistence;

namespace Zbw.Carrent.CarManagement;

public record CarCreateRequest(
    Guid Id,
    string IdentificationNr,
    CarBrand Brand,
    CarClass CarClass
    );