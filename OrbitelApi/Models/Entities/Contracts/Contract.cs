using OrbitelApi.Models.Entities.Transactions;

namespace OrbitelApi.Models.Entities.Contracts;

public class Contract
{
    public long ContractId { get; init; }

    public string ConnectAddress { get; init; } = null!;

    /// <summary>
    /// баланс по умолчанию 0 после добавления договора
    /// </summary>
    public decimal? Balance { get; init; }

    public string ContractNumber { get; init; } = null!;

    public string PersonalAccount { get; init; } = null!;

    public string? IpAddress { get; init; }

    public string? SubnetMask { get; init; }

    public string? Dns1 { get; init; }

    public string? Dns2 { get; init; }

    public string? Gateway { get; init; }

    public DateTime? CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; init; }

    public virtual ICollection<Deposit> Deposits { get; init; } = new List<Deposit>();

    public virtual ICollection<Writeoff> Writeoffs { get; init; } = new List<Writeoff>();
}
