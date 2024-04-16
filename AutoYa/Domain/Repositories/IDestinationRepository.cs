using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IDestinationRepository
{
    Task<IEnumerable<Destination>> ListAsync();
    Task AddAsync(Destination destination);
    Task<Destination> FindByIdAsync(int id);
    Task<Destination> FindByIssuerPropietaryIdAndTenantIdAsync(string issuer, int propietaryId, int tenantId);
    void Update(Destination destination);
    void Remove(Destination destination);
}