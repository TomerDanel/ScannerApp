using Application.Parser.Interface;

namespace Application.Factory.Interfaces;

/// <summary>
/// Provides a method to retrieve a parser for a specific package ecosystem.
/// </summary>
public interface IPackageFileParserFactory
{
    /// <summary>
    /// Gets a parser for the specified ecosystem (e.g., npm).
    /// </summary>
    /// <param name="ecosystem">The name of the package ecosystem.</param>
    /// <returns>An <see cref="IPackageFileParser"/> for the given ecosystem.</returns>
    IPackageFileParser GetParser(string ecosystem);
}