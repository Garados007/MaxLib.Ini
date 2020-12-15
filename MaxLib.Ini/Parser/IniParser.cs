using System.Text;
using System;
using System.IO;
namespace MaxLib.Ini.Parser
{
    public class IniParser
    {
        public virtual IniFile ParseFromString(string text, ParsingOptions options = null)
        {
            _ = text ?? throw new ArgumentNullException(nameof(text));
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
            return Parse(stream, Encoding.UTF8, options);
        }

        public virtual IniFile Parse(string path, Encoding encoding = null, ParsingOptions options = null)
        {
            _ = path ?? throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path))
                throw new FileNotFoundException("file not found", path);
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return Parse(stream, encoding, options);
        }

        public virtual IniFile Parse(Stream stream, Encoding encoding = null, ParsingOptions options = null)
        {
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
            encoding ??= Encoding.UTF8;
            if (!stream.CanRead)
                throw new ArgumentException("the stream is not readable", nameof(stream));
            using var reader = new StreamReader(stream, encoding, true, 1024, true);
            return Parse(reader, options);
        }

        public virtual IniFile Parse(TextReader reader, ParsingOptions options = null)
        {
            _ = reader ?? throw new ArgumentNullException(nameof(reader));
            options ??= new ParsingOptions();

            var file = new IniFile();
            var group = file[0];
            string line;
            int lineNum = 0;
            while ((line = reader.ReadLine()) != null)
            {
                lineNum++;
                var head = options.IniGroupHeadParser?.Parse(line, options);
                if (head != null)
                {
                    file.Add(group = head);
                    continue;
                }
                var item = options.IniGroupItemParser?.Parse(line, options);
                if (item != null)
                {
                    group.Add(item);
                    continue;
                }
                if (options.ThrowErrors)
                    throw new NotSupportedException($"Unsupported line at {lineNum}: {line}");
            }

            return file;
        }
    }
}