using AccountManager.Domain;
using AccountManager.Domain.Models;
using Contract;

namespace Repository;

public class AccountRepository: RepositoryBase<Account>, IAccountRepository
{
    public AccountRepository(RepositoryContext repositoryContext)
        :base(repositoryContext)
    {
    }

    public IEnumerable<Account> AccountsByOwner(Guid ownerId)
    {
        return FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList();
    }
}