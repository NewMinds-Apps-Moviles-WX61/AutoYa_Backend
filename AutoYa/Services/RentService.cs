﻿using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;

namespace AutoYa_Backend.AutoYa.Services;

public class RentService : IRentService
{
    private readonly IRentRepository _rentRepository;
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RentService(IRentRepository rentRepository, IUnitOfWork unitOfWork, ICarRepository carRepository)
    {
        _rentRepository = rentRepository;
        _unitOfWork = unitOfWork;
        _carRepository = carRepository;
    }

    public async Task<IEnumerable<Rent>> ListAsync()
    {
        return await _rentRepository.ListAsync();
    }

    public async Task<IEnumerable<Rent>> ListByPropietaryIdAsync(int id)
    {
        return await _rentRepository.ListByPropietaryIdAsync(id);
    }

    public async Task<IEnumerable<Rent>> ListByPlateAsync(string plate)
    {
        var car = await _carRepository.FindByPlateAsync(plate);
        
        return await _rentRepository.FindByCarIdAsync(car.Id);
    }

    public async Task<RentResponse> SaveAsync(Rent rent)
    {
        var existingCar = await _carRepository.FindByIdAsync(rent.CarId);

        if (existingCar == null)
            return new RentResponse("Car not found.");
        
        if (existingCar.Status != "AVAILABLE")
            return new RentResponse("Car is not available.");
        
        try
        {
            var existingRequest = await _rentRepository.FindByPropietaryIdTenantIdAndStatusAsync(rent.PropietaryId, rent.TenantId, rent.Status);

            if (existingRequest != null)
                return new RentResponse("Rent with that propietaryId, tenantId and status already exists.");

            rent.Status = "SUBMITTED";

            await _rentRepository.AddAsync(rent);
            await _unitOfWork.CompleteAsync();
            return new RentResponse(rent);
        }
        catch (Exception e)
        {
            return new RentResponse($"An error occurred while saving the rent: {e.Message}");
        }
    }

    public async Task<RentResponse> UpdateAsync(int id, Rent rent)
    {
        var existingRequest = await _rentRepository.FindByIdAsync(id);

        if (existingRequest == null)
            return new RentResponse("Rent not found.");

        var existingCar = await _carRepository.FindByIdAsync(existingRequest.CarId);

        if (existingCar == null)
            return new RentResponse("Car not found.");

        existingRequest.Status = rent.Status;

        existingCar.Status = rent.Status is "SUBMITTED" or "REJECTED" or "CANCELLED" or "FINISHED" ? "AVAILABLE" : "UNAVAILABLE";

    try
    {
            _rentRepository.Update(existingRequest);
            await _unitOfWork.CompleteAsync();
            _carRepository.Update(existingCar);
            await _unitOfWork.CompleteAsync();
            return new RentResponse(existingRequest);
        }
        catch (Exception e)
        {
            return new RentResponse($"An error occurred while updating the rent: {e.Message}");
        }
    }

    public async Task<RentResponse> DeleteAsync(int id)
    {
        var existingRequest = await _rentRepository.FindByIdAsync(id);

        if (existingRequest == null)
            return new RentResponse("Rent not found.");

        try
        {
            _rentRepository.Remove(existingRequest);
            await _unitOfWork.CompleteAsync();
            return new RentResponse(existingRequest);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new RentResponse($"An error occurred while deleting the request: {e.Message}");
        }
    }
}