using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface ICarReviewRepository
{
    Task<IEnumerable<CarReview>> ListAsync();
    Task<IEnumerable<CarReview>> GetByCarIdAsync(int id);
    Task AddAsync(CarReview car);
    Task<CarReview> FindByIdAsync(int id);
    Task<CarReview> FindByCarIdAndTenantIdAsync(int carId, int tenantId);
    void Update(CarReview carReview);
    void Remove(CarReview carReview);
}