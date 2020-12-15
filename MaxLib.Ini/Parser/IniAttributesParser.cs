using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
namespace MaxLib.Ini.Parser
{
    public class IniAttributesParser : ITokenParser<OptionCollection>
    {
        private static readonly Regex matcher = new Regex(
            "(?<token>(?:\"(?:[^\\\\\"]|\\\\.)*\"|[^\\\\;]|\\\\;)*)",
            RegexOptions.Compiled
        );

        public virtual OptionCollection Parse(string source, ParsingOptions options)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = options ?? throw new ArgumentNullException(nameof(options));
            if (options.IniOptionParser == null)
                return null;
            var result = new OptionCollection();
            foreach (Match match in matcher.Matches(source))
            {
                if (!match.Success)
                    continue;
                var option = options.IniOptionParser?.Parse(match.Value, options);
                if (option != null)
                    result.Add(option);
            }
            return result;
        }

        IIniElement ITokenParser.Parse(string source, ParsingOptions options)
            => Parse(source, options);
    }
}