using orbitel_api.Models.Clients;
using orbitel_api.Repositories;

namespace orbitel_api.Services;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    public async Task<List<Client>> GetAllClients()
    {
        return await clientRepository.GetAllClients();
    }
}