using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;

namespace AutoYa_Backend.AutoYa.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CarService(ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Car>> ListAsync()
    {
        return await _carRepository.ListAsync();
    }

    public async Task<CarResponse> SaveAsync(Car car)
    {
        try
        {
            var existingCar = await _carRepository.FindByPlateAsync(car.Plate);
            
            if (existingCar != null)
                return new CarResponse("Car with that plate already exists.");
            
            car.Status = "AVAILABLE";
            
            await _carRepository.AddAsync(car);
            await _unitOfWork.CompleteAsync();

            return new CarResponse(car);
        }
        catch (Exception e)
        {
            return new CarResponse($"An error occurred while saving the car: {e.Message}");
        }
    }

    public async Task<CarResponse> UpdateAsync(int id, Car car)
    {
        var existingCar = await _carRepository.FindByIdAsync(id);
        
        if (existingCar == null)
            return new CarResponse("Car not found.");
        
        existingCar.FuelType = car.FuelType;
        existingCar.Color = car.Color;
        existingCar.Mileage = car.Mileage;
        existingCar.Condition = car.Condition;
        existingCar.Price = car.Price;
        existingCar.AC = car.AC;
        existingCar.GPS = car.GPS;
        existingCar.Location = car.Location;
        
        try
        {
            _carRepository.Update(existingCar);
            await _unitOfWork.CompleteAsync();
            return new CarResponse(existingCar);
        }
        catch (Exception e)
        {
            return new CarResponse($"An error occurred while updating the car: {e.Message}");
        }
    }

    public async Task<CarResponse> UpdateStatusAsync(int id, Car car)
    {
        var existingCar = await _carRepository.FindByIdAsync(id);
        
        if (existingCar == null)
            return new CarResponse("Car not found.");
        
        existingCar.Status = car.Status;
        
        try
        {
            _carRepository.Update(existingCar);
            await _unitOfWork.CompleteAsync();
            return new CarResponse(existingCar);
        }
        catch (Exception e)
        {
            return new CarResponse($"An error occurred while updating the status of the car: {e.Message}");
        }
    }

    public async Task<CarResponse> DeleteAsync(int id)
    {
        var existingCar = await _carRepository.FindByIdAsync(id);
        
        if (existingCar == null)
            return new CarResponse("Car not found.");
        
        try
        {
            _carRepository.Remove(existingCar);
            await _unitOfWork.CompleteAsync();
            return new CarResponse(existingCar);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new CarResponse($"An error occurred while deleting the car: {e.Message}");
        }
    }
}