using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class MessageRepository : BaseRepository, IMessageRepository
{
    public MessageRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Message>> ListAsync()
    {
        return await _context.Messages.ToListAsync();
    }

    public async Task<IEnumerable<Message>> ListByDestinationIdsAsync(IEnumerable<int> destinationIds)
    {
        return await _context.Messages
            .Where(m => destinationIds.Contains(m.DestinationId))
            .ToListAsync();
    }

    public async Task AddAsync(Message message)
    {
        await _context.Messages.AddAsync(message);
    }

    public async Task<Message> FindByIdAsync(int id)
    {
        return await _context.Messages.FindAsync(id);
    }

    public void Update(Message message)
    {
        _context.Messages.Update(message);
    }

    public void Remove(Message message)
    {
        _context.Messages.Remove(message);
    }
}