namespace AccountManager.Domain.DTOs;

public class AccountDto
{
    public Guid AccountId { get; set; }
    public DateTime DateCreated { get; set; }
    public string? AccountType { get; set; }
}