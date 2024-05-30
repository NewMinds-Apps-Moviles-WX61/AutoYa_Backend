using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Resources.AuxiliarEntities;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface ICarService
{
    Task<IEnumerable<Car>> ListAsync();
    Task<IEnumerable<Car>> GetByAttributesAsync(CarSearchParams car);
    Task<IEnumerable<Car>> GetByPropietaryIdAsync(int propietaryId);
    Task<CarResponse> SaveAsync(Car car);
    Task<CarResponse> UpdateAsync(int id, Car car);
    Task<CarResponse> UpdateStatusAsync(int id, Car car);
    Task<CarResponse> DeleteAsync(int id);
}