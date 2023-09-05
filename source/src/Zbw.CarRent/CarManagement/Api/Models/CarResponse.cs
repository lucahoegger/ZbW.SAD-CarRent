using Zbw.Carrent.CarManagement.Infrastructure.Persistence;

namespace Zbw.Carrent.CarManagement;

public record CarResponse(
    Guid id,
    string identificationNr,
    CarBrand brand,
    CarClass carClass
);