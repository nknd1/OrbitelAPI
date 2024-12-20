
using Microsoft.AspNetCore.Mvc;
using OrbitelApi.DBContext;
using OrbitelApi.Models.Dtos;
using OrbitelApi.Services;

namespace OrbitelApi.Controllers;

[ApiController]
[Route("api/Client")]
public class ClientController(IClientService clientService, OrbitelContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients()
    {
        var clients = await clientService.GetAllClients();
        var response = clients.Select(c => new ClientDto(c.ClientId, c.FullName, c.Phone, c.Email));
        return Ok(response);
    }

    [HttpGet("me")]
    public IActionResult GetMe()
    {
        if (!HttpContext.Items.TryGetValue("Client", out var clientIdObj) || clientIdObj == null)
            return Unauthorized();

        if (clientIdObj is long clientId) // Проверяем, является ли объект long
        {
            var client = context.Clients.Find(clientId); // Убедитесь, что у вас есть доступ к контексту базы данных

            if (client == null)
                return NotFound();

            return Ok(new
            {
                client.Login,
                client.FullName,
                // другие данные, которые вы хотите вернуть
            });
        }

        return BadRequest("Invalid client ID format.");
    }
}