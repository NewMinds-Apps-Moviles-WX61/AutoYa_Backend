using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IMessageRepository
{
    Task<IEnumerable<Message>> ListAsync();
    Task<IEnumerable<Message>> ListByDestinationIdsAsync(IEnumerable<int> destinationIds);
    Task AddAsync(Message message);
    Task<Message> FindByIdAsync(int id);
    void Update(Message message);
    void Remove(Message message);
}