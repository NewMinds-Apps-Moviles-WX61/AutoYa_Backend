using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface ITenantService
{
    Task<IEnumerable<Tenant>> ListAsync();
    Task<Tenant> GetByIdAsync(int id);
    Task<TenantResponse> SaveAsync(Tenant tenant, User user);
    Task<TenantResponse> UpdateAsync(int id, Tenant tenant, User user);
    Task<TenantResponse> DeleteAsync(int id);
}