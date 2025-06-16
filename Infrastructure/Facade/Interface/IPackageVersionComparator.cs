namespace Infrastructure.Facade.Interface;

public interface IPackageVersionComparator
{
    bool IsVersionVulnerable(string version, string? vulnerableRange);
}