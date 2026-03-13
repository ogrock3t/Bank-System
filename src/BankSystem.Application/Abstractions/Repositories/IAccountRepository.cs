using Lab5.Domain.Entities;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Account GetById(Guid id);

    Account? FindByNumber(AccountNumber number);

    void Add(Account account);

    bool Exists(AccountNumber number);
}