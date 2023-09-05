using Microsoft.EntityFrameworkCore;
using Zbw.Carrent.CrossCutting.Infrastructure.Persistence;

namespace Zbw.Carrent.CarManagement.Infrastructure.Persistence;

public class CarRepository : ICarRepository
{
    private readonly CarRentContext _context;

    public CarRepository(CarRentContext context)
    {
        _context = context;
    }


    public IEnumerable<Car> GetAll()
    {
        return _context.Cars
            .Include(i => i.Class)
            .Include(i => i.Brand)
            .ToList();
    }

    public Car? Get(Guid id)
    {
        return _context.Cars
            .Include(f => f.Class)
            .Include(f => f.Brand)
            .FirstOrDefault(f => f.Id == id);
    }

    public Car Add(Car car)
    {
        _context.Cars.Add(car);
        _context.SaveChanges();
        return car;
    }

    public void Remove(Guid id)
    {
        var carToDelete = _context.Cars.Find(id);
        if (carToDelete != null)
        {
            _context.Cars.Remove(carToDelete);
            _context.SaveChanges();
        }
    }

    public Car Update(Car car)
    {
        _context.Cars.Update(car);
        _context.SaveChanges();
        return car;
    }
}