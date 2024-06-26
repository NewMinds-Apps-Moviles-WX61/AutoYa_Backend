using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class TenantRepository : BaseRepository, ITenantRepository
{
    public TenantRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Tenant>> ListAsync()
    {
        return await _context.Tenants.ToListAsync();
    }

    public async Task<Tenant> FindByUserIdAsync(int userId)
    {
        return await _context.Tenants
            .FirstOrDefaultAsync(t => t.UserId == userId);
    }

    public async Task AddAsync(Tenant tenant)
    {
        await _context.Tenants.AddAsync(tenant);
    }

    public async Task<Tenant> FindByIdAsync(int id)
    {
        return await _context.Tenants.FindAsync(id);
    }

    public void Update(Tenant tenant)
    {
        _context.Tenants.Update(tenant);
    }

    public void Remove(Tenant tenant)
    {
        _context.Tenants.Remove(tenant);
    }
}