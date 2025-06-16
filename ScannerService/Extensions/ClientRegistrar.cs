using Core.Models.Configuration;
using Infrastructure.Clients;
using Infrastructure.Clients.Interface;

namespace ScannerService.Extensions;

public static class ClientRegistrar
{
    public static void AddHttpGithubGraphQLClient(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        GithubGraphQLConfiguration githubGraphQlConfiguration= configuration.GetSection("Clients")
            .GetSection("GithubGraphQLConfiguration")
            .Get<GithubGraphQLConfiguration>()!;

        Uri baseUri = new Uri(githubGraphQlConfiguration.Endpoint);

        serviceCollection.AddHttpClient(nameof(GithubGraphQLClient), httpClient =>
        {
            httpClient.BaseAddress = baseUri;
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {githubGraphQlConfiguration.GithubAccessToken}");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "CycodeVulnerabilityScanner/1.0");
        });

        serviceCollection.AddSingleton<IGithubGraphQLClient, GithubGraphQLClient>();
    }
}