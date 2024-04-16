using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class BodyInformationRepository : BaseRepository, IBodyInformationRepository
{
    public BodyInformationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<BodyInformation>> ListAsync()
    {
        return await _context.BodyInformations.ToListAsync();
    }

    public async Task AddAsync(BodyInformation bodyInformation)
    {
        await _context.BodyInformations.AddAsync(bodyInformation);
    }

    public async Task<BodyInformation> FindByIdAsync(int id)
    {
        return await _context.BodyInformations.FindAsync(id);
    }

    public void Update(BodyInformation bodyInformation)
    {
        _context.BodyInformations.Update(bodyInformation);
    }

    public void Remove(BodyInformation bodyInformation)
    {
        _context.BodyInformations.Remove(bodyInformation);
    }
}