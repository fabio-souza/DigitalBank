using DigitalBank.Common.Types;

namespace DigitalBank.Domain.Entities;

public class Transaction : Entity
{
    public TransactionType Type { get; set; }

    public decimal Amount { get; set; }

    public int AccountId { get; set; }
    public Account? Account { get; set; }
}