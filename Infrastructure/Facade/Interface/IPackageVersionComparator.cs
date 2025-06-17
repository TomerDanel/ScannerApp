namespace Infrastructure.Facade.Interface;

/// <summary>
/// Provides functionality to check if a package version falls within a known vulnerable range.
/// </summary>
public interface IPackageVersionComparator
{
    /// <summary>
    /// Determines whether the specified version is vulnerable based on the given version range.
    /// </summary>
    /// <param name="version">The package version to check.</param>
    /// <param name="vulnerableRange">The range of vulnerable versions.</param>
    /// <returns>True if the version is considered vulnerable; otherwise, false.</returns>
    bool IsVersionVulnerable(string version, string? vulnerableRange);
}