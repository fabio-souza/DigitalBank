namespace DigitalBank.EntityModels;

public class Account : Entity
{
    public decimal Balance { get; private set; }

    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;

    public IEnumerable<Transaction>? Transactions { get; set; }
}