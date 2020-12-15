using System;
using System.IO;

namespace MaxLib.Ini
{
    public class IniSpace : IIniElement, IIniGroupItem
    {
        public void Write(TextWriter writer, WriteOptions options)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            _ = options ?? throw new ArgumentNullException(nameof(options));
            writer.WriteLine();
        }
    }
}