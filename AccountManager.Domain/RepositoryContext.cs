using AccountManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Domain;

public class RepositoryContext:DbContext
{
    public RepositoryContext()
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Server=127.0.0.1;Port=5433;Database=AccountManager;UserId=postgres;");
    }
    
    public DbSet<Owner>? Owners { get; set; }
    public DbSet<Account>? Accounts { get; set; }
}
