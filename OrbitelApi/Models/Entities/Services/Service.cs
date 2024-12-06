namespace OrbitelApi.Models.Entities.Services;

public  class Service
{
    public long ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public string Feature { get; set; } = null!;

    public long? ServiceTypeId { get; set; }

    /// <summary>
    /// Цена услуги
    /// </summary>
    public decimal? Price { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
