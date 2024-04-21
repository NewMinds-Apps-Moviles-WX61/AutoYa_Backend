using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface IMessageService
{
    Task<IEnumerable<Message>> ListAsync();
    Task<IEnumerable<Message>> GetAllByPropietaryIdTenantIdIssuerAndCategoryAsync(int propietaryId, int tenantId, string issuer, string category);
    Task<MessageResponse> SaveAsync(Message message, BodyInformation bodyInformation, Destination destination);
    Task<MessageResponse> UpdateAsync(int id, BodyInformation bodyInformation);
    Task<MessageResponse> DeleteAsync(int id);
}