using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class CarDocumentationRepository : BaseRepository, ICarDocumentationRepository
{
    public CarDocumentationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CarDocumentation>> ListAsync()
    {
        return await _context.CarDocumentations.ToListAsync();
    }

    public async Task<IEnumerable<CarDocumentation>> ListByCarIdAsync(int id)
    {
        return await _context.CarDocumentations.Where(p => p.CarId == id).ToListAsync();
    }

    public async Task AddAsync(CarDocumentation carDocumentation)
    {
        await _context.CarDocumentations.AddAsync(carDocumentation);
    }

    public async Task<CarDocumentation> FindByIdAsync(int id)
    {
        return await _context.CarDocumentations.FindAsync(id);
    }

    public void Update(CarDocumentation carDocumentation)
    {
        _context.CarDocumentations.Update(carDocumentation);
    }

    public void Remove(CarDocumentation carDocumentation)
    {
        _context.CarDocumentations.Remove(carDocumentation);
    }
}