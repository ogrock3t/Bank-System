using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Entities;

namespace Lab5.Application.Services;

public class TransactionService
{
    private readonly ISessionRepository _sessionRepository;

    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ISessionRepository sessionRepository, ITransactionRepository transactionRepository)
    {
        _sessionRepository = sessionRepository;
        _transactionRepository = transactionRepository;
    }

    public IReadOnlyList<Transaction> GetTransactions(Guid sessionId)
    {
        SystemSession? session = _sessionRepository.FindById(sessionId);

        if (session == null)
            throw new ArgumentException("Session not found");

        if (session.AccountId == null)
            throw new ArgumentException("Account not found");

        return _transactionRepository.FindByAccountId(session.AccountId.Value);
    }

    public Transaction GetTransaction(Guid transactionId)
    {
        Transaction? transaction = _transactionRepository.FindById(transactionId);

        if (transaction == null)
            throw new ArgumentException("Transaction not found");

        return transaction;
    }
}