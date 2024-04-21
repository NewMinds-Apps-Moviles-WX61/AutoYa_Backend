using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class RequestRepository : BaseRepository, IRequestRepository
{
    public RequestRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Request>> ListAsync()
    {
        return await _context.Requests.ToListAsync();
    }

    public async Task<IEnumerable<Request>> ListByPropietaryIdAsync(int id)
    {
        return await _context.Requests.Where(r => r.PropietaryId == id).ToListAsync();
    }

    public async Task<Request> FindByIdAsync(int id)
    {
        return await _context.Requests.FindAsync(id);
    }

    public async Task<IEnumerable<Request>> FindByCarIdAsync(int id)
    {
        return await _context.Requests.Where(r => r.CarId == id).ToListAsync();
    }

    public async Task<Request> FindByPropietaryIdTenantIdAndStatusAsync(int propietaryId, int tenantId, string status)
    {
        return await _context.Requests.Where(r => r.PropietaryId == propietaryId && r.TenantId == tenantId && r.Status == status).FirstOrDefaultAsync();
    }

    public async Task AddAsync(Request request)
    {
        await _context.Requests.AddAsync(request);
    }

    public void Update(Request request)
    {
        _context.Requests.Update(request);
    }

    public void Remove(Request request)
    {
        _context.Requests.Remove(request);
    }
}