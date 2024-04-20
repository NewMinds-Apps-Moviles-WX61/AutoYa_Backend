using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface ICarReviewService
{
    Task<IEnumerable<CarReview>> ListAsync();
    Task<IEnumerable<CarReview>> GetByCarIdAsync(int id);
    Task<CarReviewResponse> SaveAsync(CarReview carReview, BodyInformation bodyInformation);
    Task<CarReviewResponse> UpdateAsync(int id, CarReview carReview, BodyInformation bodyInformation);
    Task<CarReviewResponse> DeleteAsync(int id);
}