using OrbitelApi.Models.Entities.Clients;
using OrbitelApi.Repositories;

namespace OrbitelApi.Services;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    public async Task<List<Client>> GetAllClients()
    {
        return await clientRepository.GetAllClients();
    }
}