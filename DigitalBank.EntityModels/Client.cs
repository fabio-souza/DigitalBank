namespace DigitalBank.EntityModels;

public class Client : Entity
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public IEnumerable<Account>? Accounts { get; set; }
}
