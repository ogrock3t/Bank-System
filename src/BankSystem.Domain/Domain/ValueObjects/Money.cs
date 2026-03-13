namespace Lab5.Domain.ValueObjects;

public class Money
{
    public int Value { get; }

    public Money(int value)
    {
        if (value < 0)
            throw new ArgumentException("Money cannot be negative", nameof(value));

        Value = value;
    }

    public Money Withdrawal(Money other)
    {
        if (Value < other.Value)
            throw new ArgumentException("Money cannot be withdrawal", nameof(other));

        return new Money(Value - other.Value);
    }

    public Money Deposit(Money other)
    {
        return new Money(Value + other.Value);
    }
}