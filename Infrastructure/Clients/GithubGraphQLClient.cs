using Infrastructure.Clients.Interface;
using Infrastructure.Models.GithubVulnerabilities;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Net.Http;
using System.Threading;

namespace Infrastructure.Clients;

public class GithubGraphQLClient : IGithubGraphQLClient
{

    private readonly IHttpClientFactory _httpClientFactory;
    public readonly ILogger<GithubGraphQLClient> _logger;

    public GithubGraphQLClient(IHttpClientFactory httpClientFactory, ILogger<GithubGraphQLClient> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    #region Public Methods

    public async Task<SecurityVulnerabilities> QueryVulnerabilitiesAsync(string packageName)
    {
        try
        {
            string url = "/graphql";
            HttpClient htppClient = _httpClientFactory.CreateClient(nameof(GithubGraphQLClient));

            string query = BuildVulnerabilityQuery(packageName);
            string json = JsonSerializer.Serialize(query);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await htppClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<SecurityVulnerabilities>(responseContent);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to execute {} for {} [{}]", nameof(QueryVulnerabilitiesAsync), nameof(packageName), packageName);
            throw;
        }
    }

    #endregion

    #region Private Methods

    private string BuildVulnerabilityQuery(string packageName)
    {
        return $@"
        {{
            securityVulnerabilities(ecosystem: NPM, first: 100, package: ""{packageName}"") {{
                nodes {{
                    severity
                    advisory {{
                        summary
                    }}
                    package {{
                        name
                        ecosystem
                    }}
                    vulnerableVersionRange
                    firstPatchedVersion {{
                        identifier
                    }}
                }}
            }}
        }}";
    }

    #endregion
}