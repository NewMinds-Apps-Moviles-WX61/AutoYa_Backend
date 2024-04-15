using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class PropietaryRepository : BaseRepository, IPropietaryRepository
{
    public PropietaryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Propietary>> ListAsync()
    {
        return await _context.Propietaries.ToListAsync();
    }

    public async Task AddAsync(Propietary propietary)
    {
        await _context.Propietaries.AddAsync(propietary);
    }

    public async Task<Propietary> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Propietary propietary)
    {
        _context.Propietaries.Update(propietary);
    }

    public void Remove(Propietary propietary)
    {
        _context.Propietaries.Remove(propietary);
    }
}