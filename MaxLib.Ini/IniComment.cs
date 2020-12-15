using System;
using System.IO;

namespace MaxLib.Ini
{
    [Serializable]
    public class IniComment : IIniElement, IIniGroupItem
    {
        public string Comment { get; set; }

        public IniComment(string comment = null)
        {
            Comment = comment;
        }

        public void Write(TextWriter writer, WriteOptions options)
        {
            if (Comment == null)
                return;
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            _ = options ?? throw new ArgumentNullException(nameof(options));
            foreach (var line in Comment.Split('\n'))
            {
                writer.WriteLine($"# {line.TrimEnd()}");
            }
        }

        public override string ToString()
        {
            return $"# {Comment}";
        }
    }
}