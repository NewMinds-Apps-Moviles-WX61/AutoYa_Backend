using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;

namespace AutoYa_Backend.AutoYa.Services;

public class CarPhotoService : ICarPhotoService
{
    private readonly ICarPhotoRepository _carPhotoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CarPhotoService(ICarPhotoRepository carPhotoRepository, IUnitOfWork unitOfWork)
    {
        _carPhotoRepository = carPhotoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CarPhoto>> ListAsync()
    {
        return await _carPhotoRepository.ListAsync();
    }

    public async Task<IEnumerable<CarPhoto>> ListByCarIdAsync(int id)
    {
        return await _carPhotoRepository.ListByCarIdAsync(id);
    }

    public async Task<CarPhotoResponse> SaveAsync(CarPhoto carPhoto)
    {
        try
        {
            await _carPhotoRepository.AddAsync(carPhoto);
            await _unitOfWork.CompleteAsync();
            return new CarPhotoResponse(carPhoto);
        }
        catch (Exception e)
        {
            return new CarPhotoResponse($"An error occurred while saving the Car Photo: {e.Message}");
        }
    }

    public async Task<CarPhotoResponse> DeleteAsync(int id)
    {
        var existingCarPhoto = await _carPhotoRepository.FindByIdAsync(id);

        if (existingCarPhoto == null)
            return new CarPhotoResponse("Car Photo not found.");

        try
        {
            _carPhotoRepository.Remove(existingCarPhoto);
            await _unitOfWork.CompleteAsync();
            return new CarPhotoResponse(existingCarPhoto);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new CarPhotoResponse($"An error occurred while deleting the Car Photo: {e.Message}");
        }
    }
}