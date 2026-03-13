using Lab5.Domain.Entities.Type;
using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Entities;

public class Transaction
{
    public Transaction(Guid accountId, TransactionType type, Money value)
    {
        TransactionId = Guid.NewGuid();
        AccountId = accountId;
        Type = type;
        Value = value;
        TransactionDate = DateTime.UtcNow;
    }

    public Guid TransactionId { get; private set; }

    public Guid AccountId { get; private set; }

    public TransactionType Type { get; private set; }

    public Money Value { get; private set; }

    public DateTime TransactionDate { get; private set; }
}