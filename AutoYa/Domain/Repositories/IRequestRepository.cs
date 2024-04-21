using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IRequestRepository
{
    Task<IEnumerable<Request>> ListAsync();
    Task<IEnumerable<Request>> ListByPropietaryIdAsync(int id);
    Task<Request> FindByIdAsync(int id);
    Task<IEnumerable<Request>> FindByCarIdAsync(int id);
    Task<Request> FindByPropietaryIdTenantIdAndStatusAsync(int propietaryId, int tenantId, string status);
    Task AddAsync(Request request);
    void Update(Request request);
    void Remove(Request request);
}