using DataAccess.EFCore.Repository;

namespace DataAccess.EFCore;

public class UnitOfWork : IDisposable
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
        Developers = new DeveloperRepository(_context);
        Projects = new ProjectRepository(_context);
    }

    public DeveloperRepository Developers { get; }
    public ProjectRepository Projects { get; }

    public void Dispose()
    {
        _context.Dispose();
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }
}