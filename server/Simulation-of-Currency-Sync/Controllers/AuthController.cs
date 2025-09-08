using Microsoft.AspNetCore.Mvc;
using Simulation_of_Currency_Sync.DTOs;
using Simulation_of_Currency_Sync.Service;

namespace Simulation_of_Currency_Sync.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public AuthController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserDTO userDTO)
    {
        var token = _tokenService.GenerateTokenJWT(userDTO);

        if (token == "")
            return Unauthorized("Incorrect email or password");

        return Ok(new { token });
    }
}
