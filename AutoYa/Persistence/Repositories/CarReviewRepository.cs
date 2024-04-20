using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class CarReviewRepository : BaseRepository, ICarReviewRepository
{
    public CarReviewRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CarReview>> ListAsync()
    {
        return await _context.CarReviews.ToListAsync();
    }

    public async Task<IEnumerable<CarReview>> GetByCarIdAsync(int id)
    {
        return await _context.CarReviews.Where(c => c.CarId == id).ToListAsync();
    }

    public async Task AddAsync(CarReview carReview)
    {
        await _context.CarReviews.AddAsync(carReview);
    }

    public async Task<CarReview> FindByIdAsync(int id)
    {
        return await _context.CarReviews.FindAsync(id);
    }

    public async Task<CarReview> FindByCarIdAndTenantIdAsync(int carId, int tenantId)
    {
        return await _context.CarReviews.Where(c => c.CarId == carId && c.TenantId == tenantId).FirstOrDefaultAsync();
    }

    public void Update(CarReview carReview)
    {
        _context.CarReviews.Update(carReview);
    }

    public void Remove(CarReview carReview)
    {
        _context.CarReviews.Remove(carReview);
    }
}