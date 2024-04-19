using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface ICarPhotoRepository
{
    Task<IEnumerable<CarPhoto>> ListAsync();
    Task<IEnumerable<CarPhoto>> ListByCarIdAsync(int id);
    Task AddAsync(CarPhoto carPhoto);
    Task<CarPhoto> FindByIdAsync(int id);
    void Update(CarPhoto carPhoto);
    void Remove(CarPhoto carPhoto);
}