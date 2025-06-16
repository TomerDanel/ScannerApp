using Core.Models.Vulnerabilities;

namespace Core.Models.Scan;

public class ScanResponseEntity
{
    public IReadOnlyCollection<VulnerablePackage> VulnerablePackages { get; init; } = new List<VulnerablePackage>();
}