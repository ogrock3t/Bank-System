using Lab5.Application.Services;
using Lab5.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly TransactionService _transactionService;

    public TransactionController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost("history")]
    public IActionResult GetHistory([FromBody] Guid sessionId)
    {
        try
        {
            IReadOnlyCollection<Transaction> history = _transactionService.GetTransactions(sessionId);

            return Ok(history);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPost("id")]
    public IActionResult GetById([FromBody] Guid transactionId)
    {
        try
        {
            Transaction transaction = _transactionService.GetTransaction(transactionId);

            return Ok(transaction);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}