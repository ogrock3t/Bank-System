using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Entities;
using Lab5.Domain.ValueObjects;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class InMemoryAccountRepository : IAccountRepository
{
    private readonly List<Account> _accounts = new List<Account>();

    public Account GetById(Guid id)
    {
        return _accounts.First(account => account.AccountId == id);
    }

    public Account? FindByNumber(AccountNumber number)
    {
        return _accounts.FirstOrDefault(account => account.AccountNumber.Value == number.Value);
    }

    public void Add(Account account)
    {
        _accounts.Add(account);
    }

    public bool Exists(AccountNumber number)
    {
        return _accounts.Any(account => account.AccountNumber == number);
    }
}