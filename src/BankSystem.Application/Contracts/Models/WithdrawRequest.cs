namespace Lab5.Application.Contracts.Models;

public record WithdrawRequest(Guid SessionId, int Value);