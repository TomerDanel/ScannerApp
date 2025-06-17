using Infrastructure.Models.GithubVulnerabilities;

namespace Infrastructure.Clients.Interface;

/// <summary>
/// Provides methods for querying GitHub's GraphQL API for security vulnerabilities.
/// </summary>
public interface IGithubGraphQLClient
{
    /// <summary>
    /// Sends a GraphQL query to GitHub to retrieve vulnerabilities for a given package and ecosystem.
    /// </summary>
    /// <param name="packageName">The name of the package to check.</param>
    /// <param name="ecosystem">The package ecosystem (e.g., npm, maven).</param>
    /// <returns>A task containing the GraphQL response with vulnerability information, or null if the request fails.</returns>
    Task<GitHubGraphQLResponse?> QueryVulnerabilitiesAsync(string packageName, string ecosystem);
}