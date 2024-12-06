using orbitel_api.Models.Contracts;

namespace orbitel_api.Models.Tariffs;

public partial class TariffConnect
{
    public long TariffId { get; set; }

    public long ContractId { get; set; }

    public virtual Contract Contract { get; set; } = null!;
}
