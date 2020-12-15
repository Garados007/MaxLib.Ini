using System;

namespace MaxLib.Ini.Parser
{
    public class IniSpaceParser : ITokenParser<IniSpace>
    {
        public virtual IniSpace Parse(string source, ParsingOptions options)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = options ?? throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrWhiteSpace(source))
                return new IniSpace();
            else return null;
        }

        IIniElement ITokenParser.Parse(string source, ParsingOptions options)
            => Parse(source, options);
    }
}