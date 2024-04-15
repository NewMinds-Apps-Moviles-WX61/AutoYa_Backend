using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface ITenantRepository
{
    Task<IEnumerable<Tenant>> ListAsync();
    Task AddAsync(Tenant tenant);
    Task<Tenant> FindByIdAsync(int id);
    void Update(Tenant tenant);
    void Remove(Tenant tenant);
}