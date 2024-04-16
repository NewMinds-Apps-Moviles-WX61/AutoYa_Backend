using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IBodyInformationRepository
{
    Task<IEnumerable<BodyInformation>> ListAsync();
    Task AddAsync(BodyInformation bodyInformation);
    Task<BodyInformation> FindByIdAsync(int id);
    void Update(BodyInformation bodyInformation);
    void Remove(BodyInformation bodyInformation);
}