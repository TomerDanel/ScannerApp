namespace Application.Parser.Interface;

public interface IPackageFileParser
{
    Dictionary<string, string> ParseDependencies(string base64FileContent);
}