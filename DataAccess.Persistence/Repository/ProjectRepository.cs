using Domain;

namespace DataAccess.EFCore.Repository;

public class ProjectRepository : GenericRepository<Project>
{
    public ProjectRepository(DataContext context) : base(context)
    {
    }
}