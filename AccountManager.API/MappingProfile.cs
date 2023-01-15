using AccountManager.Domain.DTOs;
using AccountManager.Domain.Models;
using AutoMapper;

namespace AccountManager.API;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Owner, OwnerDto>();
        CreateMap<Account, AccountDto>();
        CreateMap<OwnerForCreationDto, Owner>();
        CreateMap<OwnerForUpdateDto, Owner>();
    }
}