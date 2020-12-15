using System;
namespace MaxLib.Ini.Parser
{
    public class IniGroupItemParser : ITokenParser<IIniGroupItem>
    {
        public virtual IIniGroupItem Parse(string source, ParsingOptions options)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = options ?? throw new ArgumentNullException(nameof(options));
            IIniGroupItem result;
            // space
            if ((result = options.IniSpaceParser?.Parse(source, options)) != null)
                return result;
            // comment
            if ((result = options.IniCommentParser?.Parse(source, options)) != null)
                return result;
            // option
            if ((result = options.IniOptionParser?.Parse(source, options)) != null)
                return result;
            // unknown
            return null;
        }

        IIniElement ITokenParser.Parse(string source, ParsingOptions options)
            => Parse(source, options);
    }
}