using Core.Models.Vulnerabilities;

namespace Contracts.Responses;

public record ScanResponseContract
{
    public List<VulnerablePackage> VulnerablePackages { get; set; } = new();
}