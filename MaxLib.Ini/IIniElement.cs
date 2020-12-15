using System.IO;

namespace MaxLib.Ini
{
    public interface IIniElement
    {
        void Write(TextWriter writer, WriteOptions options);
    }
}