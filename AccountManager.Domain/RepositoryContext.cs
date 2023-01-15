using AccountManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Domain;

public class RepositoryContext:DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }
    public DbSet<Owner>? Owners { get; set; }
    public DbSet<Account>? Accounts { get; set; }
}
