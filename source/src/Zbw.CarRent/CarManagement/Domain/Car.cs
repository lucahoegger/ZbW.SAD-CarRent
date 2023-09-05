namespace Zbw.Carrent.CarManagement.Infrastructure.Persistence;

public class Car
{
    public Guid Id { get; set; }

    public string IdentificationNr { get; set; }

    public CarBrand Brand { get; set; }

    public CarClass Class { get; set; }
}