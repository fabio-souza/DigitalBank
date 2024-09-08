namespace DigitalBank.Domain.Entities;

public class Client : Entity
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public IEnumerable<Account>? Accounts { get; set; }
}
