namespace Lab5.Domain.ValueObjects;

public class PinCode
{
    public string Value { get; }

    public PinCode(string value)
    {
        if (value.Length != 4)
            throw new ArgumentException("PinCode value must have exactly 4 characters.");

        if (!value.All(char.IsDigit))
            throw new ArgumentException("PinCode value must have only digits.");

        Value = value;
    }

    public bool Equals(PinCode other)
    {
        return Value == other.Value;
    }
}