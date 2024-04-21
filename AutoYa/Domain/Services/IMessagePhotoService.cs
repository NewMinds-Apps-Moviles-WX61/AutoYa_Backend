using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface IMessagePhotoService
{
    Task<IEnumerable<MessagePhoto>> ListAsync();
    Task<IEnumerable<MessagePhoto>> ListByMessageIdAsync(int id);
    Task<MessagePhotoResponse> SaveAsync(MessagePhoto messagePhoto);
    Task<MessagePhotoResponse> DeleteAsync(int id);
}