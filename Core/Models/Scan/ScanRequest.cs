namespace Core.Models.Scan;

public class ScanRequest
{
    public string Ecosystem { get; set; } = null!;
    public string FileContent { get; set; } = null!;
}