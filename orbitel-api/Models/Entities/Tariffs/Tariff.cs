namespace orbitel_api.Models.Tariffs;

public partial class Tariff
{
    public long TariffId { get; set; }

    public string TariffName { get; set; } = null!;

    public decimal PricePerMonth { get; set; }

    public string Speed { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
