using OrbitelApi.Models.Entities.Contracts;

namespace OrbitelApi.Models.Entities.Clients;

public partial class ClientContract
{
    public long ClientId { get; init; }

    public long ContractId { get; init; }

    public virtual Client Client { get; init; } = null!;

    public virtual Contract Contract { get; init; } = null!;
}
