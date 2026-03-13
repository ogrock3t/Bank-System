namespace Lab5.Application.Contracts.Models;

public record DepositRequest(Guid SessionId, int Value);