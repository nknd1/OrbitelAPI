using Microsoft.AspNetCore.Mvc;
using OrbitelApi.Models.Dtos;
using OrbitelApi.Models.Entities.Clients;

namespace OrbitelApi.Repositories;

public interface IClientRepository
{
    Task<List<Client>> GetAllClients();
    // Task<ActionResult<ClientLoginDto>> Login();
}