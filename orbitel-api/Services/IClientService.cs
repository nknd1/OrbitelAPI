using orbitel_api.Models.Clients;

namespace orbitel_api.Services;

public interface IClientService
{
   Task<List<Client>> GetAllClients();
}