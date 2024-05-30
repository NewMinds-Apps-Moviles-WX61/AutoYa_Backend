using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources.AuxiliarEntities;

namespace AutoYa_Backend.AutoYa.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IRentService _rentService;
    private readonly ICarReviewService _carReviewService;
    private readonly ICarDocumentationService _carDocumentationService;
    private readonly ICarPhotoService _carPhotoService;
    private readonly IUnitOfWork _unitOfWork;

    public CarService(ICarRepository carRepository, IUnitOfWork unitOfWork, IRentService rentService, ICarReviewService carReviewService, ICarDocumentationService carDocumentationService, ICarPhotoService carPhotoService)
    {
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
        _rentService = rentService;
        _carReviewService = carReviewService;
        _carDocumentationService = carDocumentationService;
        _carPhotoService = carPhotoService;
    }

    public async Task<IEnumerable<Car>> ListAsync()
    {
        return await _carRepository.ListAsync();
    }

    public async Task<IEnumerable<Car>> GetByAttributesAsync(CarSearchParams car)
    {
        var query = await _carRepository.GetAllCarsAsync();

        if (!string.IsNullOrEmpty(car.Plate))
            query = query.Where(c => c.Plate == car.Plate);
        if (!string.IsNullOrEmpty(car.Brand))
            query = query.Where(c => c.Brand == car.Brand);
        if (!string.IsNullOrEmpty(car.Model))
            query = query.Where(c => c.Model == car.Model);
        if (!string.IsNullOrEmpty(car.YearManufactured))
            query = query.Where(c => c.YearManufactured == car.YearManufactured);
        if (!string.IsNullOrEmpty(car.FuelType))
            query = query.Where(c => c.FuelType == car.FuelType);
        if (!string.IsNullOrEmpty(car.Transmission))
            query = query.Where(c => c.Transmission == car.Transmission);
        if (!string.IsNullOrEmpty(car.Category))
            query = query.Where(c => c.Category == car.Category);
        if (!string.IsNullOrEmpty(car.PassengerCapacity))
            query = query.Where(c => c.PassengerCapacity == car.PassengerCapacity);
        if (!string.IsNullOrEmpty(car.Color))
            query = query.Where(c => c.Color == car.Color);
        if (!string.IsNullOrEmpty(car.Mileage))
            query = query.Where(c => c.Mileage == car.Mileage);
        if (!string.IsNullOrEmpty(car.Condition))
            query = query.Where(c => c.Condition == car.Condition);
        if (car.MinPrice > 0)
            query = query.Where(c => c.Price >= car.MinPrice);
        if (car.MaxPrice > 0)
            query = query.Where(c => c.Price <= car.MaxPrice);
        if (car.AC != null)
            query = query.Where(c => c.AC == car.AC);
        if (car.GPS != null)
            query = query.Where(c => c.GPS == car.GPS);
        if (!string.IsNullOrEmpty(car.Location))
            query = query.Where(c => c.Location == car.Location);

        return query.ToList();
    }

    public async Task<IEnumerable<Car>> GetByPropietaryIdAsync(int propietaryId)
    {
        return await _carRepository.FindByPropietaryIdAsync(propietaryId);
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

        var existingRequests = await _rentService.ListByPlateAsync(existingCar.Plate);
        var existingCarReviews = await _carReviewService.GetByCarIdAsync(id);
        var existingDocumentations = await _carDocumentationService.ListByCarIdAsync(id);
        var existingCarPhotos = await _carPhotoService.ListByCarIdAsync(id);
        
        try
        {
            var deleteRequestTasks = existingRequests.Select(request => _rentService.DeleteAsync(request.Id));
            var deleteCarReviewTasks = existingCarReviews.Select(review => _carReviewService.DeleteAsync(review.Id));
            var deleteDocumentationTasks =
                existingDocumentations.Select(doc => _carDocumentationService.DeleteAsync(doc.Id));
            var deleteCarPhotoTasks = existingCarPhotos.Select(photo => _carPhotoService.DeleteAsync(photo.Id));

            await Task.WhenAll(deleteRequestTasks);
            await Task.WhenAll(deleteCarReviewTasks);
            await Task.WhenAll(deleteDocumentationTasks);
            await Task.WhenAll(deleteCarPhotoTasks);

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