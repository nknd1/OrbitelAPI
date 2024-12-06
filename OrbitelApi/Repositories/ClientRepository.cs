using Microsoft.EntityFrameworkCore;
using OrbitelApi.Models;
using OrbitelApi.DBContext;
using OrbitelApi.Models.Entities.Clients;

namespace OrbitelApi.Repositories;

public class ClientRepository(OrbitelContext context) : IClientRepository
{
    public async Task<List<Client>> GetAllClients()
    {
        var clients = await context.Clients.ToListAsync();
        return clients;
    }
}