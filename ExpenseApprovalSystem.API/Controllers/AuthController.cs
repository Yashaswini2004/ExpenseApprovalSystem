using ExpenseApprovalSystem.API.Services;
using ExpenseApprovalSystem.Contracts.AuthDTO;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseApprovalSystem.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
[HttpPost("register")]
public IActionResult Register(RegisterDto dto)
{
   
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    try
    {
       
        _authService.Register(dto);

      
        return Ok(new { message = "Registration successful" });
    }
    catch (Exception ex)
    {
       
        return BadRequest(new { message = ex.Message });
    }
}


      [HttpPost("login")]
public IActionResult Login(LoginDto dto)
{
    var result = _authService.Login(dto);

    if (result == null)
    {
        return Unauthorized("Invalid email or password"); 
    }

    return Ok(result);
}

    }
}
