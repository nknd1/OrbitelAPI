namespace OrbitelApi.Models.Dtos;

public record ContractDto(
    long ContractId,
    string ConnectAddress,
    decimal? Balance,
    string ContractNumber,
    string PersonalAccount,
    string? IpAddress,
    string? SubnetMask,
    string? Dns1,
    string? Dns2,
    string? Gateway
);