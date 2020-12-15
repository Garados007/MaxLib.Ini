using System.Collections.Generic;

namespace MaxLib.Ini.Parser
{
    public class ParsingOptions
    {
        public List<string> CommentLinePrefix { get; }
            = new List<string>{ "#" };
        
        public bool ThrowErrors { get; } = true;

        public IniCommentParser IniCommentParser { get; set; }
            = new IniCommentParser();
        
        public IniOptionParser IniOptionParser { get; set; }
            = new IniOptionParser();

        public IniSpaceParser IniSpaceParser { get; set; }
            = new IniSpaceParser();
        
        public IniGroupItemParser IniGroupItemParser { get; set; }
            = new IniGroupItemParser();

        public IniAttributesParser IniAttributesParser { get; set; }
            = new IniAttributesParser();
        
        public IniGroupHeadParser IniGroupHeadParser { get; set; }
            = new IniGroupHeadParser();
    }
}