using System.Text.Json.Serialization;

namespace Infrastructure.Models.GithubVulnerabilities;

public class Advisory
{
    [JsonPropertyName("summary")]
    public string? Summary { get; set; }
}