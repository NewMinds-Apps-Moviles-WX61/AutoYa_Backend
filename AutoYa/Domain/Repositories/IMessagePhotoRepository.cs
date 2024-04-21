using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IMessagePhotoRepository
{
    Task<IEnumerable<MessagePhoto>> ListAsync();
    Task<IEnumerable<MessagePhoto>> ListByMessageIdAsync(int id);
    Task AddAsync(MessagePhoto messagePhoto);
    Task<MessagePhoto> FindByIdAsync(int id);
    void Remove(MessagePhoto messagePhoto);
}