namespace OrbitelApi.Models.Dtos;

public record ServiceTypeDto(
    long ServiceTypeId,
    string? ServiceTypeName,
    string? Description
);