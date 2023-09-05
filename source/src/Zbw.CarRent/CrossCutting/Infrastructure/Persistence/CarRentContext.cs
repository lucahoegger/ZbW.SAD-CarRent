using Microsoft.EntityFrameworkCore;
using Zbw.Carrent.CarManagement.Infrastructure.Persistence;
using Zbw.Carrent.CustomerManagement.Domain;
using Zbw.Carrent.ReservationManagement.Domain;

namespace Zbw.Carrent.CrossCutting.Infrastructure.Persistence;

public class CarRentContext : DbContext
{
    public CarRentContext(DbContextOptions<CarRentContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }

    public DbSet<CarBrand> CarBrands { get; set; }

    public DbSet<CarClass> CarClasses { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public DbSet<RentalContract> RentalContracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarClass>().Property(p => p.DailyFee).HasPrecision(8, 2);
        modelBuilder.Entity<Reservation>().Property(p => p.TotalCosts).HasPrecision(8, 2);
    }
}