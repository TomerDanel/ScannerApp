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
        });

        serviceCollection.AddSingleton<IGithubGraphQLClient, GithubGraphQLClient>();
    }
}