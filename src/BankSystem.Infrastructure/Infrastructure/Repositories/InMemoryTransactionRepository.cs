using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Entities;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class InMemoryTransactionRepository : ITransactionRepository
{
    private readonly List<Transaction> _transactions = new List<Transaction>();

    public Transaction? FindById(Guid id)
    {
        return _transactions.FirstOrDefault(transaction => transaction.TransactionId == id);
    }

    public IReadOnlyList<Transaction> FindByAccountId(Guid accountId)
    {
        return _transactions.Where(transaction => transaction.AccountId == accountId).ToList();
    }

    public void Add(Transaction transaction)
    {
        _transactions.Add(transaction);
    }
}