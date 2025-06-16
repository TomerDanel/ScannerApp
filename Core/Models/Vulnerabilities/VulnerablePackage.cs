namespace Core.Models.Vulnerabilities;

public class VulnerablePackage
{
    public string Name { get; set; } = null!;
    public string Version { get; set; } = null!;
    public IReadOnlyCollection<Vulnerability> Vulnerabilities { get; set; } = new List<Vulnerability>();
}