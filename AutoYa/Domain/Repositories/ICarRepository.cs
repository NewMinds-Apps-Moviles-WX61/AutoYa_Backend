using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface ICarRepository
{
    Task<IEnumerable<Car>> ListAsync();
    Task<IQueryable<Car>> GetAllCarsAsync();
    Task<IEnumerable<Car>> FindByPropietaryIdAsync(int propietaryId);
    Task<IEnumerable<string>> FindAllCarBrandsAsync();
    Task<IEnumerable<Car>> FindAllAvailableCarsAsync();
    Task<IEnumerable<Car>> FindCarsByBrandAsync(string brand);
    Task AddAsync(Car car);
    Task<Car> FindByIdAsync(int id);
    Task<Car> FindByPlateAsync(string plate);
    void Update(Car car);
    void Remove(Car car);
}