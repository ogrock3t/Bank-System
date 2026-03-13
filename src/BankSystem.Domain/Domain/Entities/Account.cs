using Lab5.Domain.Entities.Result;
using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Entities;

public class Account
{
    private readonly PinCode _pinCode;

    public Account(AccountNumber accountNumber, Money money, PinCode pinCode)
    {
        AccountId = Guid.NewGuid();
        AccountNumber = accountNumber;
        Balance = money;
        _pinCode = pinCode;
    }

    public Guid AccountId { get; private set; }

    public AccountNumber AccountNumber { get; private set; }

    public Money Balance { get; private set; }

    public void Withdrawal(Money other)
    {
        Balance = Balance.Withdrawal(other);
    }

    public void Deposit(Money other)
    {
        Balance = Balance.Deposit(other);
    }

    public VerifyPinCodeResult VerifyPinCode(PinCode other)
    {
        return _pinCode.Equals(other) ? new VerifyPinCodeResult.Success() : new VerifyPinCodeResult.Failed();
    }
}