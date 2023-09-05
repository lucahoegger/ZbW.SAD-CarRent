using Microsoft.EntityFrameworkCore;

namespace Zbw.Carrent.CarManagement.Infrastructure.Persistence;

public class CarClass
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public decimal DailyFee { get; set; }
}