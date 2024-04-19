using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;

namespace AutoYa_Backend.AutoYa.Services;

public class CarDocumentationService : ICarDocumentationService
{
    private readonly ICarDocumentationRepository _carDocumentationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CarDocumentationService(ICarDocumentationRepository carDocumentationRepository, IUnitOfWork unitOfWork)
    {
        _carDocumentationRepository = carDocumentationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CarDocumentation>> ListAsync()
    {
        return await _carDocumentationRepository.ListAsync();
    }

    public async Task<IEnumerable<CarDocumentation>> ListByCarIdAsync(int id)
    {
        return await _carDocumentationRepository.ListByCarIdAsync(id);
    }

    public async Task<CarDocumentationResponse> SaveAsync(CarDocumentation carDocumentation)
    {
        try
        {
            await _carDocumentationRepository.AddAsync(carDocumentation);
            await _unitOfWork.CompleteAsync();
            return new CarDocumentationResponse(carDocumentation);
        }
        catch (Exception e)
        {
            return new CarDocumentationResponse($"An error occurred while saving the Car Documentation: {e.Message}");
        }
    }

    public async Task<CarDocumentationResponse> DeleteAsync(int id)
    {
        var existingCarDocumentation = await _carDocumentationRepository.FindByIdAsync(id);

        if (existingCarDocumentation == null)
            return new CarDocumentationResponse("Car Documentation not found.");

        try
        {
            _carDocumentationRepository.Remove(existingCarDocumentation);
            await _unitOfWork.CompleteAsync();
            return new CarDocumentationResponse(existingCarDocumentation);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new CarDocumentationResponse($"An error occurred while deleting the Car Documentation: {e.Message}");
        }
    }
}