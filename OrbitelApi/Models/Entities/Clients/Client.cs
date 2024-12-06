using System.Text.Json.Serialization;

namespace OrbitelApi.Models.Entities.Clients;

public class Client
{
    public long ClientId { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string SeriesPass { get; set; } = null!;

    public string NumberPass { get; set; } = null!;

    public string IssuedBy { get; set; } = null!;

    public DateOnly IssueDate { get; set; }

    public string AddressRegistration { get; set; } = null!;

    public string Inn { get; init; } = null!;

    public string Phone { get; init; } = null!;

    public string Login { get; init; } = null!;

    public string? Email { get; init; }
    [JsonIgnore]
    public string PasswordHash { get; init; } = null!;
}
