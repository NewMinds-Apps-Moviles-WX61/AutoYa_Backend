using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;

namespace AutoYa_Backend.AutoYa.Services;

public class CarReviewService : ICarReviewService
{
    private readonly ICarReviewRepository _carReviewRepository;
    private readonly IBodyInformationRepository _bodyInformationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CarReviewService(ICarReviewRepository carReviewRepository, IUnitOfWork unitOfWork, IBodyInformationRepository bodyInformationRepository)
    {
        _carReviewRepository = carReviewRepository;
        _unitOfWork = unitOfWork;
        _bodyInformationRepository = bodyInformationRepository;
    }

    public async Task<IEnumerable<CarReview>> ListAsync()
    {
        return await _carReviewRepository.ListAsync();
    }

    public async Task<IEnumerable<CarReview>> GetByCarIdAsync(int id)
    {
        return await _carReviewRepository.GetByCarIdAsync(id);
    }

    public async Task<CarReviewResponse> SaveAsync(CarReview carReview, BodyInformation bodyInformation)
    {
        try
        {
            var existingCarReview = await _carReviewRepository.FindByCarIdAndTenantIdAsync(carReview.CarId, carReview.TenantId);

            if (existingCarReview != null)
                return new CarReviewResponse("CarReview with that plate already exists.");
            
            // Agregar el BodyInformation
            await _bodyInformationRepository.AddAsync(bodyInformation);
            await _unitOfWork.CompleteAsync();

            // Obtener el ID del bodyInformation generado automáticamente
            var bodyInformationId = bodyInformation.Id;
            
            carReview.BodyInformationId = bodyInformationId;
            
            await _carReviewRepository.AddAsync(carReview);
            await _unitOfWork.CompleteAsync();

            return new CarReviewResponse(carReview);
        }
        catch (Exception e)
        {
            return new CarReviewResponse($"An error occurred while saving the carReview: {e.Message}");
        }
    }

    public async Task<CarReviewResponse> UpdateAsync(int id, CarReview carReview, BodyInformation bodyInformation)
    {
        var existingCarReview = await _carReviewRepository.FindByIdAsync(id);

        if (existingCarReview == null)
            return new CarReviewResponse("CarReview not found.");

        var existingBodyInformation = await _bodyInformationRepository.FindByIdAsync(existingCarReview.BodyInformationId);
        
        if (existingBodyInformation == null)
            return new CarReviewResponse("BodyInformation not found.");

        existingCarReview.Score = carReview.Score;
        
        existingBodyInformation.Text = bodyInformation.Text;
        existingBodyInformation.Date = bodyInformation.Date;
        existingBodyInformation.Time = bodyInformation.Time;
        
        try
        {
            _carReviewRepository.Update(existingCarReview);
            await _unitOfWork.CompleteAsync();
            _bodyInformationRepository.Update(existingBodyInformation);
            await _unitOfWork.CompleteAsync();
            return new CarReviewResponse(existingCarReview);
        }
        catch (Exception e)
        {
            return new CarReviewResponse($"An error occurred while updating the carReview: {e.Message}");
        }
    }

    public async Task<CarReviewResponse> DeleteAsync(int id)
    {
        var existingCarReview = await _carReviewRepository.FindByIdAsync(id);

        if (existingCarReview == null)
            return new CarReviewResponse("CarReview not found.");

        var existingBodyInformation = await _bodyInformationRepository.FindByIdAsync(existingCarReview.BodyInformationId);
        
        if (existingBodyInformation == null)
            return new CarReviewResponse("BodyInformation not found.");
        
        try
        {
            _carReviewRepository.Remove(existingCarReview);
            await _unitOfWork.CompleteAsync();
            _bodyInformationRepository.Remove(existingBodyInformation);
            await _unitOfWork.CompleteAsync();
            return new CarReviewResponse(existingCarReview);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new CarReviewResponse($"An error occurred while deleting the carReview: {e.Message}");
        }
    }
}