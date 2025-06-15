using Application.Parser.Interface;

namespace Application.Factory.Interfaces;

public interface IPackageFileParserFactory
{
    IPackageFileParser GetParser(string ecosystem);
}