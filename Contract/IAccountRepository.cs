using AccountManager.Domain.Models;

namespace Contract;

public interface IAccountRepository: IRepositoryBase<Account>
{
    IEnumerable<Account> AccountsByOwner(Guid ownerId);
}