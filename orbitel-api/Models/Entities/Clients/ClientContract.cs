using orbitel_api.Models.Contracts;

namespace orbitel_api.Models.Clients;

public partial class ClientContract
{
    public long ClientId { get; init; }

    public long ContractId { get; init; }

    public virtual Client Client { get; init; } = null!;

    public virtual Contract Contract { get; init; } = null!;
}
