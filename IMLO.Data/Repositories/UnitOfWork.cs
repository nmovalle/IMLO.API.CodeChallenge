using IMLO.Data.Interfaces;

namespace IMLO.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IMLODbContext _context;


    public UnitOfWork(IMLODbContext context)
    {
        _context = context;

    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
