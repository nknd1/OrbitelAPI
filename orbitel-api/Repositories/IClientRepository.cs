using orbitel_api.Models.Clients;

namespace orbitel_api.Repositories;

public interface IClientRepository
{
    Task<List<Client>> GetAllClients();
}