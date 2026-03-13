using Lab5.Application.Contracts.Models;
using Lab5.Application.Services;
using Lab5.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionController : ControllerBase
{
    private readonly SessionService _sessionService;

    public SessionController(SessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        try
        {
            SystemSession systemSession = _sessionService.CreateUserSession(request.AccountNumber, request.PinCode);

            return Ok(systemSession);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("admin-login")]
    public IActionResult AdminLogin([FromBody] AdminLoginRequest request)
    {
        try
        {
            SystemSession systemSession = _sessionService.CreateAdminSession(request.SystemPassword);

            return Ok(systemSession);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}