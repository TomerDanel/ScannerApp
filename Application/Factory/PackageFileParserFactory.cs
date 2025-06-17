using Application.Factory.Interfaces;
using Application.Parser;
using Application.Parser.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Factory;

public class PackageFileParserFactory : IPackageFileParserFactory
{
    private readonly IServiceProvider _serviceProvider;

    public PackageFileParserFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IPackageFileParser GetParser(string ecosystem)
    {
        return (ecosystem.ToLower() switch
        {
            "npm" => _serviceProvider.GetRequiredService<NpmPackageParser>(),
            _ => throw new NotSupportedException($"Ecosystem '{ecosystem}' is not supported.")
        })!;
    }
}