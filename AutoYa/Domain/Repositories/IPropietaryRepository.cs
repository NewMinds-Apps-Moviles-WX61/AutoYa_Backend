using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IPropietaryRepository
{
    Task<IEnumerable<Propietary>> ListAsync();
    Task AddAsync(Propietary propietary);
    Task<Propietary> FindByIdAsync(int id);
    void Update(Propietary propietary);
    void Remove(Propietary propietary);
}