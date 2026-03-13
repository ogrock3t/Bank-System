using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Entities;
using Lab5.Domain.Entities.Type;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Services;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;

    private readonly ISessionRepository _sessionRepository;

    private readonly ITransactionRepository _transactionRepository;

    public AccountService(
        IAccountRepository accountRepository,
        ISessionRepository sessionRepository,
        ITransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _sessionRepository = sessionRepository;
        _transactionRepository = transactionRepository;
    }

    public void CreateAccount(Guid sessionId, string accountNumber, string pinCode, int balance)
    {
        SystemSession? session = _sessionRepository.FindById(sessionId);

        if (session == null)
            throw new ArgumentException($"Session {sessionId} does not exist");

        var accountNumberVO = new AccountNumber(accountNumber);

        if (_accountRepository.Exists(accountNumberVO))
            throw new ArgumentException($"Account number {accountNumber} is already exists");

        var account = new Account(accountNumberVO, new Money(balance), new PinCode(pinCode));

        _accountRepository.Add(account);
    }

    public int GetBalance(Guid sessionId)
    {
        SystemSession? session = _sessionRepository.FindById(sessionId);

        if (session == null)
            throw new ArgumentException($"Session {sessionId} does not exist");

        if (session.AccountId == null)
            throw new ArgumentException($"Account {sessionId} not found");

        Account account = _accountRepository.GetById(session.AccountId.Value);

        return account.Balance.Value;
    }

    public void Withdraw(Guid sessionId, int amount)
    {
        SystemSession? session = _sessionRepository.FindById(sessionId);

        if (session == null)
            throw new ArgumentException($"Session {sessionId} does not exist");

        if (session.AccountId == null)
            throw new ArgumentException($"Account {sessionId} not found");

        Account account = _accountRepository.GetById(session.AccountId.Value);

        var withdraw = new Money(amount);

        account.Withdrawal(withdraw);

        var transaction = new Transaction(account.AccountId, TransactionType.Withdraw, withdraw);

        _transactionRepository.Add(transaction);
    }

    public void Deposit(Guid sessionId, int amount)
    {
        SystemSession? session = _sessionRepository.FindById(sessionId);

        if (session == null)
            throw new ArgumentException($"Session {sessionId} does not exist");

        if (session.AccountId == null)
            throw new ArgumentException($"Account {sessionId} not found");

        Account account = _accountRepository.GetById(session.AccountId.Value);

        var withdraw = new Money(amount);

        account.Deposit(withdraw);

        var transaction = new Transaction(account.AccountId, TransactionType.Deposit, withdraw);

        _transactionRepository.Add(transaction);
    }
}