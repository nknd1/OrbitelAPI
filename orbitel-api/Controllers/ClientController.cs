
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orbitel_api.Models;
using orbitel_api.Models.Clients;
using orbitel_api.Services;

namespace orbitel_api.Controllers;

[ApiController]
[Route("api/Client")] 
public class ClientController(IClientService clientService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ClientDto>>> GetClients()
    {
        var clients = await clientService.GetAllClients();
        var response = clients.Select(c => new ClientDto(c.ClientId, c.FullName, c.Phone, c.Email));
        return Ok(response);
    }
}