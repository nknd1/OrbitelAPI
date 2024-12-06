namespace OrbitelApi.Models.Dtos;

public class TariffDto
{
    public long TariffId { get; set; }

    public string TariffName { get; set; } = null!;

    public decimal PricePerMonth { get; set; }

    public string Speed { get; set; } = null!;

    public string? Status { get; set; }
}