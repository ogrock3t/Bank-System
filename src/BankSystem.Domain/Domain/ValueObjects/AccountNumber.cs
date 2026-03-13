namespace Lab5.Domain.ValueObjects;

public class AccountNumber
{
    public string Value { get; }

    public AccountNumber(string value)
    {
        if (!value.All(char.IsDigit))
            throw new ArgumentException("Account number value must have only digits.");

        Value = value;
    }
}