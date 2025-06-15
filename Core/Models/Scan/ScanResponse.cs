using Core.Models.Vulnerabilities;

namespace Core.Models.Scan;

public class ScanResponse
{
    public List<VulnerablePackage> VulnerablePackages { get; set; } = new();
}