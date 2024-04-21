using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;

namespace AutoYa_Backend.AutoYa.Services;

public class MessagePhotoService : IMessagePhotoService
{
    private readonly IMessagePhotoRepository _messagePhotoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MessagePhotoService(IMessagePhotoRepository messagePhotoRepository, IUnitOfWork unitOfWork)
    {
        _messagePhotoRepository = messagePhotoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<MessagePhoto>> ListAsync()
    {
        return await _messagePhotoRepository.ListAsync();
    }

    public async Task<IEnumerable<MessagePhoto>> ListByMessageIdAsync(int id)
    {
        return await _messagePhotoRepository.ListByMessageIdAsync(id);
    }

    public async Task<MessagePhotoResponse> SaveAsync(MessagePhoto messagePhoto)
    {
        try
        {
            await _messagePhotoRepository.AddAsync(messagePhoto);
            await _unitOfWork.CompleteAsync();
            return new MessagePhotoResponse(messagePhoto);
        }
        catch (Exception e)
        {
            return new MessagePhotoResponse($"An error occurred while saving the Message Photo: {e.Message}");
        }
    }

    public async Task<MessagePhotoResponse> DeleteAsync(int id)
    {
        var existingMessagePhoto = await _messagePhotoRepository.FindByIdAsync(id);

        if (existingMessagePhoto == null)
            return new MessagePhotoResponse("Message Photo not found.");

        try
        {
            _messagePhotoRepository.Remove(existingMessagePhoto);
            await _unitOfWork.CompleteAsync();
            return new MessagePhotoResponse(existingMessagePhoto);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new MessagePhotoResponse($"An error occurred while deleting the Message Photo: {e.Message}");
        }
    }
}