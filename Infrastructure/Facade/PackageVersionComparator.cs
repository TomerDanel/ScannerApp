using Infrastructure.Facade.Interface;

namespace Infrastructure.Facade;

public class PackageVersionComparator : IPackageVersionComparator
{
    public bool IsVersionVulnerable(string version, string? vulnerableRange)
    {
        if (string.IsNullOrEmpty(vulnerableRange))
            return false;

        return vulnerableRange.Contains(version) ||
               CheckLessThanOrEqualCondition(version, vulnerableRange) ||
               CheckLessThanCondition(version, vulnerableRange);
    }

    public bool CheckLessThanOrEqualCondition(string version, string vulnerableRange)
    {
        return vulnerableRange.StartsWith("<=") &&
               string.Compare(version, vulnerableRange[2..].Trim(), StringComparison.Ordinal) <= 0;
    }

    public bool CheckLessThanCondition(string version, string vulnerableRange)
    {
        return vulnerableRange.StartsWith("<") &&
               string.Compare(version, vulnerableRange[1..].Trim(), StringComparison.Ordinal) < 0;
    }
}