using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Developer> Developers { get; set; }
    public DbSet<Project> Projects { get; set; }
}