using AccountManager.Domain.Models;
using Contract;
using Moq;

namespace AccountManager.Tests;

internal class MockIOwnerRepository
{
    public static Mock<IOwnerRepository> GetMock()
    {
        var mock = new Mock<IOwnerRepository>();
        var owners = new List<Owner>()
        {
            new Owner()
            {
                OwnerId = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                Name = "John",
                DateOfBirth = DateTime.Now.AddYears(-20),
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        OwnerId = new Guid(),
                        AccountType = "",
                        DateCreated = DateTime.Now
                    }
                }
            },
            new Owner()
            {
                OwnerId = Guid.Parse("9f8fad5b-d9cb-469f-a165-70867728950a"),
                Name = "Frank",
                DateOfBirth = DateTime.Now.AddYears(-20),
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        OwnerId = new Guid(),
                        AccountType = "",
                    }
                }
            }
        };
        mock.Setup(m => m.GetAllOwners())
            .Returns(() => owners);
        mock.Setup(m => m.GetOwnerById(It.IsAny<Guid>()))
            .Returns((Guid id) => owners.FirstOrDefault(o => o.OwnerId == id));
        mock.Setup(m => m.GetOwnerWithDetails(It.IsAny<Guid>()))
            .Returns((Guid id) => owners.FirstOrDefault(o => o.OwnerId == id));
        mock.Setup(m => m.CreateOwner(It.IsAny<Owner>()))
            .Callback(() => { return; });
        mock.Setup(m => m.UpdateOwner(It.IsAny<Owner>()))
            .Callback(() => { return; });
        mock.Setup(m => m.DeleteOwner(It.IsAny<Owner>()))
            .Callback(() => { return; });
        
        return mock;
        
    }
}