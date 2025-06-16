using System.Text.Json.Serialization;

namespace Infrastructure.Models.GithubVulnerabilities;

public record SecurityVulnerabilities
{
    [JsonPropertyName("nodes")]
    public List<VulnerabilityNode> Nodes { get; set; } = new();
}