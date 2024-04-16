using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class CarRepository : BaseRepository, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Car>> ListAsync()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task AddAsync(Car car)
    {
        await _context.Cars.AddAsync(car);
    }

    public async Task<Car> FindByIdAsync(int id)
    {
        return await _context.Cars.FindAsync(id);
    }

    public async Task<Car> FindByPlateAsync(string plate)
    {
        return await _context.Cars.Where(c => c.Plate == plate).FirstOrDefaultAsync();
    }

    public void Update(Car car)
    {
        _context.Cars.Update(car);
    }

    public void Remove(Car car)
    {
        _context.Cars.Remove(car);
    }
}