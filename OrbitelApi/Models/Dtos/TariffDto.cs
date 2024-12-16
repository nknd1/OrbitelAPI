namespace OrbitelApi.Models.Dtos;

public record TariffDto(
    long TariffId,
    string TariffName,
    decimal PricePerMonth,
    string Speed,
    string? Status
);