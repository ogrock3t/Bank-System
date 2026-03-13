using Lab5.Domain.Entities;

namespace Lab5.Application.Abstractions.Repositories;

public interface ITransactionRepository
{
    Transaction? FindById(Guid id);

    IReadOnlyList<Transaction> FindByAccountId(Guid accountId);

    void Add(Transaction transaction);
}