using System.Collections.Generic;
namespace MaxLib.Ini
{
    public interface IIniCollection<T> : IList<T>, ICollection<T>, IEnumerable<T>
        where T : IIniGroupItem
    {
        IniOption this[string name] { get; set; }

        IEnumerable<IniOption> GetAll();

        void Add(IniOption option);

        void Set(IniOption option);

        void Remove(string name);
    }
}