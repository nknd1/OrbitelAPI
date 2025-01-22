
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        if (clientIdObj is not long clientId)
            return BadRequest("Invalid client ID format."); // Проверяем, является ли объект long

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

    [HttpGet("contracts")]
    public async Task<IActionResult> GetContract()
    {
        // Проверяем, есть ли идентификатор клиента в HttpContext
        if (!HttpContext.Items.TryGetValue("Client", out var clientIdObj) || clientIdObj == null)
            return Unauthorized();

        // Пробуем преобразовать clientIdObj к int
        int clientId;
        
        try
        {
            clientId = Convert.ToInt32(clientIdObj);
        }
        catch (InvalidCastException)
        {
            return BadRequest("Неверный формат идентификатора клиента.");
        }
        catch (OverflowException)
        {
            return BadRequest("Идентификатор клиента слишком велик.");
        }

        var contracts = await context.ClientContracts
            .Where(cc => cc.ClientId == clientId)
            .Select(cc => new
            {
                cc.Contract.ContractId,
                cc.Contract.ContractNumber,
                cc.Contract.ConnectAddress,
                cc.Contract.Balance,
                cc.Contract.PersonalAccount
            })
            .ToListAsync();
        
        if (contracts.Count == 0)
            return NotFound("Договоры не найдены для данного клиента.");
        
        return Ok(contracts);
    }
}