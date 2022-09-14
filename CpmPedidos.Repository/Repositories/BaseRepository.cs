namespace CpmPedidos.Repository.Repositories;

public class BaseRepository
{
    protected readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }
}