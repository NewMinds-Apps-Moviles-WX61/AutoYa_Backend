using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface ICarService
{
    Task<IEnumerable<Car>> ListAsync();
    Task<CarResponse> SaveAsync(Car car);
    Task<CarResponse> UpdateAsync(int id, Car car);
    Task<CarResponse> UpdateStatusAsync(int id, Car car);
    Task<CarResponse> DeleteAsync(int id);
}