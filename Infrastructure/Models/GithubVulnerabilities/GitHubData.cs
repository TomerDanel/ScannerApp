using System.Text.Json.Serialization;

namespace Infrastructure.Models.GithubVulnerabilities;

public class GitHubData
{
    [JsonPropertyName("securityVulnerabilities")]
    public SecurityVulnerabilities? SecurityVulnerabilities { get; set; }
}