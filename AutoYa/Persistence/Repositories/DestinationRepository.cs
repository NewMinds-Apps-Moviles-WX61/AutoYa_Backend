using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class DestinationRepository : BaseRepository, IDestinationRepository
{
    public DestinationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Destination>> ListAsync()
    {
        return await _context.Destinations.ToListAsync();
    }

    public async Task AddAsync(Destination destination)
    {
        await _context.Destinations.AddAsync(destination);
    }

    public async Task<Destination> FindByIdAsync(int id)
    {
        return await _context.Destinations.FindAsync(id);
    }

    public async Task<Destination> FindByIssuerPropietaryIdAndTenantIdAsync(string issuer, int propietaryId, int tenantId)
    {
        return await _context.Destinations.Where(d => d.Issuer == issuer && d.PropietaryId == propietaryId && d.TenantId == tenantId).FirstOrDefaultAsync();
    }

    public void Update(Destination destination)
    {
        _context.Destinations.Update(destination);
    }

    public void Remove(Destination destination)
    {
        _context.Destinations.Remove(destination);
    }
}