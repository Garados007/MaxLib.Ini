using System.Text.RegularExpressions;
using System;
namespace MaxLib.Ini.Parser
{
    public class IniGroupHeadParser : ITokenParser<IniGroup>
    {
        private static readonly Regex matcher = new Regex(
            "^\\[(?<name>\"(?:[^\\\\\"]|\\\\.)*\"|[^\\](\\\"]*)(?:\\((?<args>.*)\\))?\\]$",
            RegexOptions.Compiled
        );

        public virtual IniGroup Parse(string source, ParsingOptions options)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = options ?? throw new ArgumentNullException(nameof(options));
            var match = matcher.Match(source);
            if (!match.Success)
                return null;
            var result = new IniGroup(match.Groups["name"].Value);
            if (match.Groups["args"].Success)
            {
                var args = options.IniAttributesParser?.Parse(match.Groups["args"].Value, options);
                if (args != null)
                    foreach (var item in args)
                        result.Attributes.Add(item);
            }
            return result;
        }

        IIniElement ITokenParser.Parse(string source, ParsingOptions options)
            => Parse(source, options);
    }
}