using System.Text.Json.Serialization;

namespace Infrastructure.Models.GithubVulnerabilities;

public class PatchedVersion
{
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }
}