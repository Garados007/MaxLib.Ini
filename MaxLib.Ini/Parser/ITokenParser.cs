namespace MaxLib.Ini.Parser
{
    public interface ITokenParser
    {
        IIniElement Parse(string source, ParsingOptions options);
    }

    public interface ITokenParser<T> : ITokenParser
        where T : IIniElement
    {
        new T Parse(string source, ParsingOptions options);
    }
}