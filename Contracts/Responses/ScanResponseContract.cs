using Core.Models.Vulnerabilities;

namespace Contracts.Responses;

public record ScanResponseContract
{
    public IReadOnlyCollection<VulnerablePackage> VulnerablePackages { get; init; } = new List<VulnerablePackage>();
}