namespace ScannerService.Extentions;

public static class ClientRegistrar
{
    public static void AddHttpQualificationClient(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        //QualificationServiceConfiguration qualificationConfiguration = configuration.GetSection("Clients")
        //    .GetSection("QualificationServiceConfiguration")
        //    .Get<QualificationServiceConfiguration>();

        //Uri baseUri = new Uri(qualificationConfiguration.Endpoint);
        //TimeSpan timeout = TimeSpan.FromSeconds(qualificationConfiguration.Timeout);

        //serviceCollection.AddHttpClient(nameof(QualificationClient), httpClient =>
        //{
        //    httpClient.BaseAddress = baseUri;
        //    httpClient.Timeout = timeout;
        //});
        //serviceCollection.AddSingleton<IQualificationClient, QualificationClient>();
    }
}