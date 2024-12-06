using orbitel_api.Models.Tariffs;

namespace orbitel_api.Models.Services;

public class ServiceConnect
{
    public long ServiceId { get; set; }

    public long TariffId { get; set; }

    public virtual Service Service { get; set; } = null!;

    public virtual Tariff Tariff { get; set; } = null!;
}
