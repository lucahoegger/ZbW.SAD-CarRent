namespace Zbw.Carrent.CarManagement.Infrastructure.Persistence;

public interface ICarRepository
{
    IEnumerable<Car> GetAll();
    Car? Get(Guid id);
    Car Add(Car car);
    void Remove(Guid id);
    Car Update(Car car);
}