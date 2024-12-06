using OrbitelApi.Models.Entities.Contracts;

namespace OrbitelApi.Models.Entities.Transactions;

public class Deposit
{
    public long DepositId { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? DateDeposit { get; set; }

    public TimeOnly? TimeDeposit { get; set; }

    public long? ContractId { get; set; }

    public virtual Contract? Contract { get; set; }
}
