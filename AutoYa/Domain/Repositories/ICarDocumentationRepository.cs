using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface ICarDocumentationRepository
{
    Task<IEnumerable<CarDocumentation>> ListAsync();
    Task<IEnumerable<CarDocumentation>> ListByCarIdAsync(int id);
    Task AddAsync(CarDocumentation carDocumentation);
    Task<CarDocumentation> FindByIdAsync(int id);
    void Update(CarDocumentation carDocumentation);
    void Remove(CarDocumentation carDocumentation);
}