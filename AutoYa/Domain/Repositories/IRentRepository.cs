using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IRentRepository
{
    Task<IEnumerable<Rent>> ListAsync();
    Task<IEnumerable<Rent>> ListByPropietaryIdAsync(int id);
    Task<IEnumerable<Rent>> GetAllRentsByTenantIdAsync(int id);
    Task<Rent> FindByIdAsync(int id);
    Task<IEnumerable<Rent>> FindByCarIdAsync(int id);
    Task<Rent> FindCurrentlyOpenRentByPropietaryIdTenantIdAndCarIdAsync(int propietaryId, int tenantId, int carId);
    Task AddAsync(Rent rent);
    void Update(Rent rent);
    void Remove(Rent rent);
}