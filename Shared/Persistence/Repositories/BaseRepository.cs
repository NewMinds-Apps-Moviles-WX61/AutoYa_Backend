using AutoYa_Backend.Shared.Persistence.Contexts;

namespace AutoYa_Backend.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}