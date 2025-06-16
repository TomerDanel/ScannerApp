using System.Text.Json.Serialization;

namespace Infrastructure.Models.GithubVulnerabilities;

public class Package
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("ecosystem")]
    public string? Ecosystem { get; set; }
}