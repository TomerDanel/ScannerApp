using Infrastructure.Models.GithubVulnerabilities;

namespace Infrastructure.Clients.Interface;

public interface IGithubGraphQLClient
{
    Task<GitHubGraphQLResponse?> QueryVulnerabilitiesAsync(string packageName, string ecosystem);
}