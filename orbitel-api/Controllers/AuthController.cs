using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using orbitel_api.Models;
using orbitel_api.Models.Clients;
using orbitel_api.Models.Dtos;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace orbitel_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(OrbitelContext context, IConfiguration _configuration) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] ClientRegisterDto dto)
    {
        if (context.Clients.Any(c => c.FullName == dto.FullName))
        {
            return BadRequest("Клиент уже существует");
        }

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash);

        var client = new Client
        {
            FullName = dto.FullName,
            DateOfBirth = dto.DateOfBirth,
            SeriesPass = dto.SeriesPass,
            NumberPass = dto.NumberPass,
            IssuedBy = dto.IssuedBy,
            IssueDate = dto.IssueDate,
            AddressRegistration = dto.AddressRegistration,
            Inn = dto.Inn,
            Phone = dto.Phone,
            Login = dto.Login,
            Email = dto.Email ?? null,
            PasswordHash = passwordHash
        };
        context.Clients.Add(client);
        await context.SaveChangesAsync();

        return Ok("Клиент успешно создан");
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] ClientLoginDto loginDto)
    {
        var client = await context.Clients.SingleOrDefaultAsync(c => c.Login == loginDto.Login);
        if (client == null || !BCrypt.Net.BCrypt.Verify(loginDto.PasswordHash, client.PasswordHash))
            return Unauthorized("Неверные данные для входа");

        var token = GenerateJwtToken(client);
        return Ok(new { Token = token });
    }

    private string GenerateJwtToken(Client client)
    {
        // Получаем настройки JWT
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"];

        // Проверяем длину ключа
        if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32)
            throw new InvalidOperationException("SecretKey должен быть не менее 32 символов.");

        // Настраиваем токен
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, client.Login),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("ClientId", client.ClientId.ToString()),
            new Claim("FullName", client.FullName)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
