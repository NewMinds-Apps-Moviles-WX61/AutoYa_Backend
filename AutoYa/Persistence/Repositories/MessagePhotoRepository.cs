using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoYa_Backend.AutoYa.Persistence.Repositories;

public class MessagePhotoRepository : BaseRepository, IMessagePhotoRepository
{
    public MessagePhotoRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<MessagePhoto>> ListAsync()
    {
        return await _context.MessagePhotos.ToListAsync();
    }

    public async Task<IEnumerable<MessagePhoto>> ListByMessageIdAsync(int id)
    {
        return await _context.MessagePhotos.Where(p => p.MessageId == id).ToListAsync();
    }

    public async Task AddAsync(MessagePhoto messagePhoto)
    {
        await _context.MessagePhotos.AddAsync(messagePhoto);
    }

    public async Task<MessagePhoto> FindByIdAsync(int id)
    {
        return await _context.MessagePhotos.FindAsync(id);
    }

    public void Remove(MessagePhoto messagePhoto)
    {
        _context.MessagePhotos.Remove(messagePhoto);
    }
}