using Microsoft.AspNetCore.Mvc;
using PT.Data;
using PT.DTOs;
using PT.Services;

namespace PT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly JwtService _jwt;

    public AuthController(AppDbContext context, JwtService jwt)
    {
        _context = context;
        _jwt = jwt;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO dto)
    {
        var user = _context.Users
            .FirstOrDefault(x => x.Email == dto.Email && x.Password == dto.Password);

        if (user == null)
            return Unauthorized(new { message = "Credenciales incorrectas" });

        var token = _jwt.GenerateToken(user.Email);

        return Ok(new
        {
            email = user.Email,
            token
        });
    }
}
