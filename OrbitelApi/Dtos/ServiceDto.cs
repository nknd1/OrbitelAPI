namespace OrbitelApi.Models.Dtos;

public record ServiceDto(
    long ServiceId,
    string ServiceName,
    string Feature,
    long? ServiceTypeId,
    decimal? Price
);