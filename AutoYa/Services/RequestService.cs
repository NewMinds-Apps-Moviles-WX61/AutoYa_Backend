using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;

namespace AutoYa_Backend.AutoYa.Services;

public class RequestService : IRequestService
{
    private readonly IRequestRepository _requestRepository;
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RequestService(IRequestRepository requestRepository, IUnitOfWork unitOfWork, ICarRepository carRepository)
    {
        _requestRepository = requestRepository;
        _unitOfWork = unitOfWork;
        _carRepository = carRepository;
    }

    public async Task<IEnumerable<Request>> ListAsync()
    {
        return await _requestRepository.ListAsync();
    }

    public async Task<IEnumerable<Request>> ListByPropietaryIdAsync(int id)
    {
        return await _requestRepository.ListByPropietaryIdAsync(id);
    }

    public async Task<IEnumerable<Request>> ListByPlateAsync(string plate)
    {
        var car = await _carRepository.FindByPlateAsync(plate);
        
        return await _requestRepository.FindByCarIdAsync(car.Id);
    }

    public async Task<RequestResponse> SaveAsync(Request request)
    {
        var existingCar = await _carRepository.FindByIdAsync(request.CarId);

        if (existingCar == null)
            return new RequestResponse("Car not found.");
        
        if (existingCar.Status != "AVAILABLE")
            return new RequestResponse("Car is not available.");
        
        try
        {
            var existingRequest = await _requestRepository.FindByPropietaryIdTenantIdAndStatusAsync(request.PropietaryId, request.TenantId, request.Status);

            if (existingRequest != null)
                return new RequestResponse("Request with that propietaryId, tenantId and status already exists.");

            request.Status = "SUBMITTED";

            await _requestRepository.AddAsync(request);
            await _unitOfWork.CompleteAsync();
            return new RequestResponse(request);
        }
        catch (Exception e)
        {
            return new RequestResponse($"An error occurred while saving the request: {e.Message}");
        }
    }

    public async Task<RequestResponse> UpdateAsync(int id, Request request)
    {
        var existingRequest = await _requestRepository.FindByIdAsync(id);

        if (existingRequest == null)
            return new RequestResponse("Request not found.");

        var existingCar = await _carRepository.FindByIdAsync(existingRequest.CarId);

        if (existingCar == null)
            return new RequestResponse("Car not found.");

        existingRequest.Status = request.Status;

        existingCar.Status = request.Status is "SUBMITTED" or "UNDERREVIEW" or "REJECTED" or "CANCELLED" ? "AVAILABLE" : "UNAVAILABLE";

    try
    {
            _requestRepository.Update(existingRequest);
            await _unitOfWork.CompleteAsync();
            _carRepository.Update(existingCar);
            await _unitOfWork.CompleteAsync();
            return new RequestResponse(existingRequest);
        }
        catch (Exception e)
        {
            return new RequestResponse($"An error occurred while updating the request: {e.Message}");
        }
    }

    public async Task<RequestResponse> DeleteAsync(int id)
    {
        var existingRequest = await _requestRepository.FindByIdAsync(id);

        if (existingRequest == null)
            return new RequestResponse("Request not found.");

        try
        {
            _requestRepository.Remove(existingRequest);
            await _unitOfWork.CompleteAsync();
            return new RequestResponse(existingRequest);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new RequestResponse($"An error occurred while deleting the request: {e.Message}");
        }
    }
}