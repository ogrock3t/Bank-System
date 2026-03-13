using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Entities;
using Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public class MockAccountRepository : IAccountRepository
{
    private readonly Dictionary<Guid, Account> _accountsById = new Dictionary<Guid, Account>();

    private readonly Dictionary<string, Account> _accountsByNumber = new Dictionary<string, Account>();

    public Account GetById(Guid id)
    {
        if (!_accountsById.TryGetValue(id, out Account? account))
            throw new ArgumentException($"Account with ID {id} does not exist");

        return account;
    }

    public Account? FindByNumber(AccountNumber number)
    {
        return _accountsByNumber.GetValueOrDefault(number.Value);
    }

    public void Add(Account account)
    {
        _accountsById[account.AccountId] = account;
        _accountsByNumber[account.AccountNumber.Value] = account;
    }

    public bool Exists(AccountNumber number)
    {
        return _accountsByNumber.ContainsKey(number.Value);
    }
}