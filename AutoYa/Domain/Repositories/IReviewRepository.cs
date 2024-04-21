using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IReviewRepository
{
    Task<IEnumerable<Review>> ListAsync();
    Task<Review> FindByIdAsync(int id);
    Task<Review> FindByDestinationIdAsync(int id);
    Task AddAsync(Review review);
    void Update(Review review);
    void Remove(Review review);
}