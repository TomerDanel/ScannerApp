using Core.Models.Vulnerabilities;

namespace Core.Models.Scan;

public class ScanResponseEntity
{
    public List<VulnerablePackage> VulnerablePackages { get; set; } = new();
}