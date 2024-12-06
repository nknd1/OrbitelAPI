using OrbitelApi.Models.Entities.Clients;

namespace OrbitelApi.Repositories;

public interface IClientRepository
{
    Task<List<Client>> GetAllClients();
}