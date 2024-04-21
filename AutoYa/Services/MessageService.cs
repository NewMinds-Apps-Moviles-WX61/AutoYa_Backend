using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;

namespace AutoYa_Backend.AutoYa.Services;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly IBodyInformationRepository _bodyInformationRepository;
    private readonly IDestinationRepository _destinationRepository;
    private readonly IPropietaryRepository _propietaryRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MessageService(IMessageRepository messageRepository, IBodyInformationRepository bodyInformationRepository, IDestinationRepository destinationRepository, IUnitOfWork unitOfWork, IPropietaryRepository propietaryRepository, ITenantRepository tenantRepository)
    {
        _messageRepository = messageRepository;
        _bodyInformationRepository = bodyInformationRepository;
        _destinationRepository = destinationRepository;
        _unitOfWork = unitOfWork;
        _propietaryRepository = propietaryRepository;
        _tenantRepository = tenantRepository;
    }

    public async Task<IEnumerable<Message>> ListAsync()
    {
        return await _messageRepository.ListAsync();
    }

    public async Task<IEnumerable<Message>> GetAllByPropietaryIdTenantIdIssuerAndCategoryAsync(int propietaryId,
        int tenantId, string issuer, string category)
    {
        // Obtener los IDs de los destinatarios
        var destinationIds = await _destinationRepository.ListDestinationIdsByPropietaryIdTenantIdIssuerAndCategoryAsync(propietaryId, tenantId, issuer, category);

        return await _messageRepository.ListByDestinationIdsAsync(destinationIds);
    }

    public async Task<MessageResponse> SaveAsync(Message message, BodyInformation bodyInformation, Destination destination)
    {
        try
        {
            var existingPropietary = await _propietaryRepository.FindByIdAsync(destination.PropietaryId);

            if (existingPropietary == null)
                return new MessageResponse("Propietary not found.");

            var existingTenant = await _tenantRepository.FindByIdAsync(destination.TenantId);

            if (existingTenant == null)
                return new MessageResponse("Tenant not found.");

            await _bodyInformationRepository.AddAsync(bodyInformation);
            await _unitOfWork.CompleteAsync();

            // Obtener el ID del bodyInformation generado automáticamente
            var bodyInformationId = bodyInformation.Id;

            await _destinationRepository.AddAsync(destination);
            await _unitOfWork.CompleteAsync();

            // Obtener el ID del destination generado automaticamente
            var destinationId = destination.Id;

            // Asignar los IDs autogenerados al message
            message.BodyInformationId = bodyInformationId;
            message.DestinationId = destinationId;

            await _messageRepository.AddAsync(message);
            await _unitOfWork.CompleteAsync();
            return new MessageResponse(message);
        }
        catch (Exception e)
        {
            return new MessageResponse($"An error occurred while saving the message: {e.Message}");
        }
    }

    public async Task<MessageResponse> UpdateAsync(int id, BodyInformation bodyInformation)
    {
        var existingMessage = await _messageRepository.FindByIdAsync(id);

        if (existingMessage == null)
            return new MessageResponse("Message not found.");

        var existingBodyInformation = await _bodyInformationRepository.FindByIdAsync(existingMessage.BodyInformationId);

        if (existingBodyInformation == null)
            return new MessageResponse("BodyInformation not found.");

        existingBodyInformation.Text = bodyInformation.Text;
        existingBodyInformation.Date = bodyInformation.Date;
        existingBodyInformation.Time = bodyInformation.Time;

        try
        {
            _messageRepository.Update(existingMessage);
            await _unitOfWork.CompleteAsync();
            _bodyInformationRepository.Update(existingBodyInformation);
            await _unitOfWork.CompleteAsync();
            return new MessageResponse(existingMessage);
        }
        catch (Exception e)
        {
            return new MessageResponse($"An error occurred while updating the message: {e.Message}");
        }
    }

    public async Task<MessageResponse> DeleteAsync(int id)
    {
        var existingMessage = await _messageRepository.FindByIdAsync(id);

        if (existingMessage == null)
            return new MessageResponse("Message not found.");

        var existingBodyInformation = await _bodyInformationRepository.FindByIdAsync(existingMessage.BodyInformationId);

        if (existingBodyInformation == null)
            return new MessageResponse("BodyInformation not found.");

        var existingDestination = await _destinationRepository.FindByIdAsync(existingMessage.DestinationId);

        if (existingDestination == null)
            return new MessageResponse("Destination not found.");

        try
        {
            _messageRepository.Remove(existingMessage);
            await _unitOfWork.CompleteAsync();
            _bodyInformationRepository.Remove(existingBodyInformation);
            await _unitOfWork.CompleteAsync();
            _destinationRepository.Remove(existingDestination);
            await _unitOfWork.CompleteAsync();
            return new MessageResponse(existingMessage);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new MessageResponse($"An error occurred while deleting the message: {e.Message}");
        }
    }
}