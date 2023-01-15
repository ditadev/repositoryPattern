using System.Net;
using AccountManager.API;
using AccountManager.API.Controllers;
using AccountManager.Domain.DTOs;
using AccountManager.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace AccountManager.Tests;

public class AccountManagerControllerTest
{
    public IMapper GetMapper()
    {
        var mappingProfile = new MappingProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
        return new Mapper(configuration);
    }

    [Fact]
    public void WhenGettingAllOwners_ThenAllOwnersReturn()
    {
        var mock = new Mock<ILogger<AccountManagerController>>();
        ILogger<AccountManagerController> logger = mock.Object;
        
        var repositoryWrapperMock = MockRepositoryWrapper.GetMock();
        var mapper = GetMapper();
        var accountManagerController = new AccountManagerController(repositoryWrapperMock.Object, logger, mapper);
    
        var result = accountManagerController.GetAllOwners() as ObjectResult;
        
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.IsAssignableFrom<IEnumerable<OwnerDto>>(result.Value);
        Assert.NotEmpty(result.Value as IEnumerable<OwnerDto>);
    }
    
    [Fact]
    public void GivenAnIdOfAnExistingOwner_WhenGettingOwnerById_ThenOwnerReturns()
    {
        var mock = new Mock<ILogger<AccountManagerController>>();
        ILogger<AccountManagerController> logger = mock.Object;
        
        var repositoryWrapperMock = MockRepositoryWrapper.GetMock();
        var mapper = GetMapper();
        var ownerController = new AccountManagerController(repositoryWrapperMock.Object,logger, mapper);

        var id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e");
        var result = ownerController.GetOwnerById(id) as ObjectResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.IsAssignableFrom<OwnerDto>(result.Value);
        Assert.NotNull(result.Value as OwnerDto);
    }
    
    [Fact]
    public void GivenAnIdOfANonExistingOwner_WhenGettingOwnerById_ThenNotFoundReturns()
    {
        var mock = new Mock<ILogger<AccountManagerController>>();
        ILogger<AccountManagerController> logger = mock.Object;
        
        var repositoryWrapperMock = MockRepositoryWrapper.GetMock();
        var mapper = GetMapper();
        var ownerController = new AccountManagerController(repositoryWrapperMock.Object, logger, mapper);

        var id = Guid.Parse("f4f4e3bf-afa6-4399-87b5-a3fe17572c4d");
        var result = ownerController.GetOwnerById(id) as StatusCodeResult;

        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
    }
    
    [Fact]
    public void GivenValidRequest_WhenCreatingOwner_ThenCreatedReturns()
    {
        var mock = new Mock<ILogger<AccountManagerController>>();
        ILogger<AccountManagerController> logger = mock.Object;
        
        var repositoryWrapperMock = MockRepositoryWrapper.GetMock();
        var mapper = GetMapper();
        var ownerController = new AccountManagerController(repositoryWrapperMock.Object, logger, mapper);

        var owner = new OwnerForCreationDto()
        {
            Address = "TestAddress",
            Name = "TestName",
            DateOfBirth = new DateTime(1994, 7, 25)
        };

        var result = ownerController.CreateOwner(owner);

        Assert.NotNull(result);
    }
}