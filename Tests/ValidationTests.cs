using System.ComponentModel.DataAnnotations;
using AccountManager.Domain.DTOs;

namespace AccountManager.Tests;

public class ValidationTests
{
    private bool ValidateModel(object model)
    {
        var validationResults = new List<ValidationResult>();
        var ctx = new ValidationContext(model, null, null);
 
        return Validator.TryValidateObject(model, ctx, validationResults, true);
    }
    
    [Theory]
    [InlineData(null, null, null, false)]
    [InlineData(null, "TestAddress", null, false)]
    [InlineData(null, null, "06/04/1994", false)]
    [InlineData("TestName", null, null, false)]
    [InlineData(null, "TestAddress", "06/04/1994", false)]
    [InlineData("TestName", null, "06/04/1994", false)]
    [InlineData("TestName", "TestAddress", "06/04/1994", true)]
    [InlineData("TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest", "TestAdress", "06/04/1994", false)]
    public void TestModelValidation(string? name, string? address, string? dateOfBirth, bool isValid)
    {
        var owner = new OwnerForCreationDto()
        {
            Address = address,
            Name = name,
            DateOfBirth = dateOfBirth is null ? DateTime.MinValue : DateTime.Parse(dateOfBirth)
        };
    
        Assert.Equal(isValid, ValidateModel(owner));
    }
}