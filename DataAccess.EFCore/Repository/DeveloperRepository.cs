using Domain;
using Serilog;

namespace DataAccess.EFCore.Repository;

public class DeveloperRepository:GenericRepository<Developer>
{
    public DeveloperRepository(DataContext context):base(context)
    {
    }
    public IEnumerable<Developer> GetPopularDevelopers(int count)
    {
        Log.Debug("Debug logging for Developer with {@person} popularity at {now}", count, DateTime.Now);
        Log.Verbose("Verbose logging for Developer with {@person} popularity at {now}", count, DateTime.Now);
        Log.Information("Information logging forDeveloper with {@person} popularity at {now}", count, DateTime.Now);
        Log.Fatal("Fatal logging for Developer with {@person} popularity at {now}", count, DateTime.Now);
        Log.Error("Error logging for Developer with {@person} popularity at {now}", count, DateTime.Now);
        Log.Warning("Warning Developer with {@person} popularity at {now}", count, DateTime.Now);

        return _context.Developers.OrderByDescending(d => d.Followers).Take(count).ToList();
    }
}