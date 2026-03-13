using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Entities;
using Lab5.Domain.Entities.Result;
using Lab5.Domain.Entities.Type;
using Lab5.Domain.ValueObjects;
using Microsoft.Extensions.Configuration;

namespace Lab5.Application.Services;

public class SessionService
{
    private readonly string _systemPassword;

    private readonly ISessionRepository _sessionRepository;

    private readonly IAccountRepository _accountRepository;

    public SessionService(
        ISessionRepository sessionRepository,
        IAccountRepository accountRepository,
        IConfiguration configuration)
    {
        _sessionRepository = sessionRepository;
        _accountRepository = accountRepository;
        _systemPassword = configuration["SystemPassword"] ??
                          throw new InvalidOperationException("SystemPassword not found");
    }

    public SystemSession CreateUserSession(string accountNumber, string pinCode)
    {
        var accountNumberVO = new AccountNumber(accountNumber);

        Account? account = _accountRepository.FindByNumber(accountNumberVO);

        if (account == null)
            throw new ArgumentException($"Account number {accountNumber} not found");

        var pinCodeVO = new PinCode(pinCode);

        VerifyPinCodeResult verifyResult = account.VerifyPinCode(pinCodeVO);

        if (verifyResult is not VerifyPinCodeResult.Success)
            throw new ArgumentException($"Pin code {pinCode} is not valid");

        var session = new SystemSession(account.AccountId, SessionType.User);

        _sessionRepository.Add(session);

        return session;
    }

    public SystemSession CreateAdminSession(string systemPassword)
    {
        if (systemPassword != _systemPassword)
            throw new ArgumentException("Passwords do not match");

        var session = new SystemSession(null, SessionType.Admin);

        _sessionRepository.Add(session);

        return session;
    }
}