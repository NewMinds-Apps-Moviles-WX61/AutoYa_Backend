using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IDestinationRepository
{
    Task<IEnumerable<Destination>> ListAsync();
    Task<IEnumerable<int>> ListDestinationIdsByPropietaryIdTenantIdIssuerAndCategoryAsync(int propietaryId, int tenantId, string issuer, string category);
    Task AddAsync(Destination destination);
    Task<Destination> FindByIdAsync(int id);
    Task<Destination> FindByIssuerPropietaryIdTenantIdAndCategoryAsync(string issuer, int propietaryId, int tenantId, string category);
    void Update(Destination destination);
    void Remove(Destination destination);
}