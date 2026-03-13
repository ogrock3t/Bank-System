using Lab5.Application.Contracts.Models;
using Lab5.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("create")]
    public IActionResult CreateAccount([FromBody] CreateAccountRequest request)
    {
        try
        {
            _accountService.CreateAccount(request.SessionId, request.AccountNumber, request.PinCode, request.Balance);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("balance")]
    public IActionResult GetBalance([FromBody] BalanceRequest request)
    {
        try
        {
            int balance = _accountService.GetBalance(request.SessionId);

            return Ok(balance);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("withdraw")]
    public IActionResult Withdraw([FromBody] WithdrawRequest request)
    {
        try
        {
            _accountService.Withdraw(request.SessionId, request.Value);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("deposit")]
    public IActionResult Deposit([FromBody] DepositRequest request)
    {
        try
        {
            _accountService.Deposit(request.SessionId, request.Value);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}