using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class RentRepository : BaseRepository, IRentRepository
{
    public RentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Rent>> ListAsync()
    {
        return await _context.Requests.ToListAsync();
    }

    public async Task<IEnumerable<Rent>> ListByPropietaryIdAsync(int id)
    {
        return await _context.Requests.Where(r => r.PropietaryId == id).ToListAsync();
    }

    public async Task<IEnumerable<Rent>> GetAllRentsByTenantIdAsync(int id)
    {
        return await _context.Requests.Where(r => r.TenantId == id).ToListAsync();
    }

    public async Task<Rent> FindByIdAsync(int id)
    {
        return await _context.Requests.FindAsync(id);
    }

    public async Task<IEnumerable<Rent>> FindByCarIdAsync(int id)
    {
        return await _context.Requests.Where(r => r.CarId == id).ToListAsync();
    }

    public async Task<Rent> FindCurrentlyOpenRentByPropietaryIdTenantIdAndCarIdAsync(int propietaryId, int tenantId, int carId)
    {
        return await _context.Requests.Where(r => r.PropietaryId == propietaryId && r.TenantId == tenantId && r.CarId == carId).FirstOrDefaultAsync();
    }

    public async Task AddAsync(Rent rent)
    {
        await _context.Requests.AddAsync(rent);
    }

    public void Update(Rent rent)
    {
        _context.Requests.Update(rent);
    }

    public void Remove(Rent rent)
    {
        _context.Requests.Remove(rent);
    }
}