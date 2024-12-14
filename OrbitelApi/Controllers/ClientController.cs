
using Microsoft.AspNetCore.Mvc;
using OrbitelApi.Models.Dtos;
using OrbitelApi.Services;

namespace OrbitelApi.Controllers;

[ApiController]
[Route("api/Client")] 
public class ClientController(IClientService clientService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients()
    {
        var clients = await clientService.GetAllClients();
        var response = clients.Select(c => new ClientDto(c.ClientId, c.FullName, c.Phone, c.Email));
        return Ok(response);
    }
}