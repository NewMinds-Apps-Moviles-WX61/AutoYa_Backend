using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface IRentService
{
    Task<IEnumerable<Rent>> ListAsync();
    Task<IEnumerable<Rent>> ListByPropietaryIdAsync(int id);
    Task<IEnumerable<Rent>> ListByPlateAsync(string plate);
    Task<RentResponse> SaveAsync(Rent rent);
    Task<RentResponse> UpdateAsync(int id, Rent rent);
    Task<RentResponse> DeleteAsync(int id);
}