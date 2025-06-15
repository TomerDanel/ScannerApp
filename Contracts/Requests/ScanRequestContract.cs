using System.ComponentModel.DataAnnotations;

namespace Contracts.Requests;

public record ScanRequestContract(string Ecosystem, string FileContent);