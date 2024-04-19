using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class CarPhotoRepository : BaseRepository, ICarPhotoRepository
{
    public CarPhotoRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CarPhoto>> ListAsync()
    {
        return await _context.CarPhotos.ToListAsync();
    }

    public async Task<IEnumerable<CarPhoto>> ListByCarIdAsync(int id)
    {
        return await _context.CarPhotos.Where(p => p.CarId == id).ToListAsync();
    }

    public async Task AddAsync(CarPhoto carPhoto)
    {
        await _context.CarPhotos.AddAsync(carPhoto);
    }

    public async Task<CarPhoto> FindByIdAsync(int id)
    {
        return await _context.CarPhotos.FindAsync(id);
    }

    public void Update(CarPhoto carPhoto)
    {
        _context.CarPhotos.Update(carPhoto);
    }

    public void Remove(CarPhoto carPhoto)
    {
        _context.CarPhotos.Remove(carPhoto);
    }
}