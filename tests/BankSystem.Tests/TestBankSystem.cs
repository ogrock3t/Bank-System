using Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;
using Lab5.Application.Services;
using Lab5.Domain.Entities;
using Lab5.Domain.Entities.Type;
using Lab5.Domain.ValueObjects;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TestBankSystem
{
    [Fact]
    public void Withdraw_WithSufficientBalance_ShouldUpdateBalanceCorrectly()
    {
        // Arrange
        var accountRepository = new MockAccountRepository();
        var sessionRepository = new MockSessionRepository();
        var transactionRepository = new MockTransactionRepository();

        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?> { ["SystemPassword"] = "admin", }).Build();

        var accountService = new AccountService(accountRepository, sessionRepository, transactionRepository);
        var sessionService = new SessionService(sessionRepository, accountRepository, configuration);

        string accountNumber = "1";
        var accountNumberVO = new AccountNumber(accountNumber);
        string pinCode = "1234";
        int initialBalance = 1000;
        int withdrawalAmount = 200;
        int expectedBalance = initialBalance - withdrawalAmount;

        SystemSession adminSession = sessionService.CreateAdminSession("admin");
        accountService.CreateAccount(adminSession.SessionId, accountNumber, pinCode, initialBalance);
        Account? createdAccount = accountRepository.FindByNumber(accountNumberVO);
        Assert.NotNull(createdAccount);

        var session = new SystemSession(createdAccount.AccountId, SessionType.User);
        sessionRepository.Add(session);

        // Act
        accountService.Withdraw(session.SessionId, withdrawalAmount);

        // Assert
        Assert.Equal(expectedBalance, createdAccount.Balance.Value);
    }

    [Fact]
    public void Withdraw_WithSufficientBalance_ShouldThrowException()
    {
        // Arrange
        var accountRepository = new MockAccountRepository();
        var sessionRepository = new MockSessionRepository();
        var transactionRepository = new MockTransactionRepository();

        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?> { ["SystemPassword"] = "admin", }).Build();

        var accountService = new AccountService(accountRepository, sessionRepository, transactionRepository);
        var sessionService = new SessionService(sessionRepository, accountRepository, configuration);

        string accountNumber = "1";
        var accountNumberVO = new AccountNumber(accountNumber);
        string pinCode = "1234";
        int initialBalance = 100;
        int withdrawalAmount = 200;

        SystemSession adminSession = sessionService.CreateAdminSession("admin");
        accountService.CreateAccount(adminSession.SessionId, accountNumber, pinCode, initialBalance);
        Account? createdAccount = accountRepository.FindByNumber(accountNumberVO);
        Assert.NotNull(createdAccount);

        var session = new SystemSession(createdAccount.AccountId, SessionType.User);
        sessionRepository.Add(session);

        // Act && Assert
        Assert.Throws<ArgumentException>(() => accountService.Withdraw(session.SessionId, withdrawalAmount));
    }

    [Fact]
    public void Deposit_WithSufficientBalance_ShouldUpdateBalanceCorrectly()
    {
        // Arrange
        var accountRepository = new MockAccountRepository();
        var sessionRepository = new MockSessionRepository();
        var transactionRepository = new MockTransactionRepository();

        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?> { ["SystemPassword"] = "admin", }).Build();

        var accountService = new AccountService(accountRepository, sessionRepository, transactionRepository);
        var sessionService = new SessionService(sessionRepository, accountRepository, configuration);

        string accountNumber = "1";
        var accountNumberVO = new AccountNumber(accountNumber);
        string pinCode = "1234";
        int initialBalance = 70;
        int withdrawalAmount = 200;
        int expectedBalance = initialBalance + withdrawalAmount;

        SystemSession adminSession = sessionService.CreateAdminSession("admin");
        accountService.CreateAccount(adminSession.SessionId, accountNumber, pinCode, initialBalance);
        Account? createdAccount = accountRepository.FindByNumber(accountNumberVO);
        Assert.NotNull(createdAccount);

        var session = new SystemSession(createdAccount.AccountId, SessionType.User);
        sessionRepository.Add(session);

        // Act
        accountService.Deposit(session.SessionId, withdrawalAmount);

        // Assert
        Assert.Equal(expectedBalance, createdAccount.Balance.Value);
    }
}