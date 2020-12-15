using System;
namespace MaxLib.Ini.Parser
{
    public class IniCommentParser : ITokenParser<IniComment>
    {
        public virtual IniComment Parse(string source, ParsingOptions options)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = options ?? throw new ArgumentNullException(nameof(options));
            foreach (var prefix in options.CommentLinePrefix)
            {
                if (!source.StartsWith(prefix))
                    continue;
                source = source.Substring(prefix.Length);
                return new IniComment(source);
            }
            return null;
        }

        IIniElement ITokenParser.Parse(string source, ParsingOptions options)
            => Parse(source, options);
    }
}