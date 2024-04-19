using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface ICarPhotoService
{
    Task<IEnumerable<CarPhoto>> ListAsync();
    Task<IEnumerable<CarPhoto>> ListByCarIdAsync(int id);
    Task<CarPhotoResponse> SaveAsync(CarPhoto carPhoto);
    Task<CarPhotoResponse> DeleteAsync(int id);
}