namespace Lab5.Application.Contracts.Models;

public record CreateAccountRequest(Guid SessionId, string AccountNumber, string PinCode, int Balance);