using orbitel_api.Models.Contracts;

namespace orbitel_api.Models.Transactions;

public class Deposit
{
    public long DepositId { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? DateDeposit { get; set; }

    public TimeOnly? TimeDeposit { get; set; }

    public long? ContractId { get; set; }

    public virtual Contract? Contract { get; set; }
}
