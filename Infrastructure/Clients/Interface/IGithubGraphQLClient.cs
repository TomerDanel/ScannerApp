using Infrastructure.Models.GithubVulnerabilities;

namespace Infrastructure.Clients.Interface;

public interface IGithubGraphQLClient
{
    Task<SecurityVulnerabilities> QueryVulnerabilitiesAsync(string packageName);
}