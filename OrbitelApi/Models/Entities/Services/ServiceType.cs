namespace OrbitelApi.Models.Entities.Services;

public partial class ServiceType
{
    public long ServiceTypeId { get; set; }

    public string? ServiceTypeName { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
