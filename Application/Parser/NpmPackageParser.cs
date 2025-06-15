using Application.Parser.Interface;
using System.Text;
using System.Text.Json;

namespace Application.Parser;

public class NpmPackageParser : IPackageFileParser
{
    public Dictionary<string, string> ParseDependencies(string base64FileContent)
    {
        var dependencies = new Dictionary<string, string>();
        var json = Encoding.UTF8.GetString(Convert.FromBase64String(base64FileContent));

        using var doc = JsonDocument.Parse(json);
        if (doc.RootElement.TryGetProperty("dependencies", out var d))
        {
            foreach (JsonProperty prop in d.EnumerateObject())
            {
                var version = prop.Value.GetString();
                if (!string.IsNullOrWhiteSpace(version))
                    dependencies[prop.Name] = version;
            }
        }

        return dependencies;
    }
}