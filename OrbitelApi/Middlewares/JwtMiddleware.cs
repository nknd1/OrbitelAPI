using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace orbitel_api.Middlewares;

public class JwtMiddleware(RequestDelegate next, IConfiguration configuration)
{
    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            AttachUserToContext(context, token);

        await next(context);
    }

    private void AttachUserToContext(HttpContext context, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["JwtSettings:SecretKey"] ?? string.Empty);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var clientIdString = jwtToken.Claims.First(x => x.Type == "ClientId").Value;

            // Преобразуем clientId в long и сохраняем в контексте
            if (long.TryParse(clientIdString, out var clientId))
            {
                // Здесь вы можете загрузить данные клиента из базы данных и прикрепить их к контексту
                context.Items["Client"] = clientId; // Сохраняем как long
            }
            else
            {
                // Логируем или обрабатываем ошибку преобразования clientId
                throw new Exception("Invalid ClientId format.");
            }
        }
        catch (Exception ex)
        {
            // Логируем ошибку валидации токена или преобразования clientId
            Console.WriteLine($"Error attaching user to context: {ex.Message}");
        }
    }
}
