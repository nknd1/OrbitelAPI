using OrbitelApi.Models.Entities.Contracts;

namespace OrbitelApi.Models.Entities.Tariffs;

public partial class TariffConnect
{
    public long TariffId { get; set; }

    public long ContractId { get; set; }

    public virtual Contract Contract { get; set; } = null!;
}
