using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface ICarDocumentationService
{
    Task<IEnumerable<CarDocumentation>> ListAsync();
    Task<IEnumerable<CarDocumentation>> ListByCarIdAsync(int id);
    Task<CarDocumentationResponse> SaveAsync(CarDocumentation carDocumentation);
    Task<CarDocumentationResponse> DeleteAsync(int id);
}