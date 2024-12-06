using orbitel_api.Models.Contracts;

namespace orbitel_api.Models.Transactions;

public partial class Writeoff
{
    public long WriteoffId { get; set; }

    public decimal? Amount { get; set; }

    public string Reason { get; set; } = null!;

    public DateOnly? DateWriteoff { get; set; }

    public TimeOnly? TimeWriteoff { get; set; }

    public long? ContractId { get; set; }

    public virtual Contract? Contract { get; set; }
}
