namespace orbitel_api.Models.Contracts;

public class ContractDto
{
    public long ContractId { get; set; }    

    public string ConnectAddress { get; set; } = null!;

    /// <summary>
    /// баланс по умолчанию 0 после добавления договора
    /// </summary>
    public decimal? Balance { get; set; }

    public string ContractNumber { get; set; } = null!;

    public string PersonalAccount { get; set; } = null!;

    public string? IpAddress { get; set; }

    public string? SubnetMask { get; set; }

    public string? Dns1 { get; set; }

    public string? Dns2 { get; set; }

    public string? Gateway { get; set; }
}