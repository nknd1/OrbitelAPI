using OrbitelApi.Models.Entities.Clients;

namespace OrbitelApi.Services;

public interface IClientService
{
   Task<List<Client>> GetAllClients();
}