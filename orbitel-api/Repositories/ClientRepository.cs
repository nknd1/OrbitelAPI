using Microsoft.EntityFrameworkCore;
using orbitel_api.Models;
using orbitel_api.Models.Clients;

namespace orbitel_api.Repositories;

public class ClientRepository(OrbitelContext context) : IClientRepository
{
    public async Task<List<Client>> GetAllClients()
    {
        var clients = await context.Clients.ToListAsync();
        return clients;
    }
}