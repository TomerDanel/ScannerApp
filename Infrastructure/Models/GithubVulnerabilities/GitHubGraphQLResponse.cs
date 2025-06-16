using System.Text.Json.Serialization;

namespace Infrastructure.Models.GithubVulnerabilities;

public class GitHubGraphQLResponse
{
    [JsonPropertyName("data")]
    public GitHubData? Data { get; set; }
}