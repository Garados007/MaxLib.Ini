using System.Text.RegularExpressions;
using System;

namespace MaxLib.Ini.Parser
{
    public class IniOptionParser : ITokenParser<IniOption>
    {
        static Regex matcher = new Regex(
            "^\\s*(?<key>\"(?:[^\"\\\\]|\\\\.)*\"|[^\\[][^=]*)\\s*(?:=\\s*(?<value>.*))?$",
            RegexOptions.Compiled
        );

        public virtual IniOption Parse(string source, ParsingOptions options)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = options ?? throw new ArgumentNullException(nameof(options));
            var match = matcher.Match(source);
            if (!match.Success)
                return null;
            return new IniOption(
                Tools.ResolveValidationName(
                    match.Groups["key"].Value.Trim()
                ),
                match.Groups["value"].Success ?
                    match.Groups["value"].Value.Trim() : ""
            );
        }

        IIniElement ITokenParser.Parse(string source, ParsingOptions options)
            => Parse(source, options);
    }
}