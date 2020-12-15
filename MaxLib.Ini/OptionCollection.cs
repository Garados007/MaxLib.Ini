using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MaxLib.Ini
{
    public class OptionCollection : IIniCollection<IniOption>, IIniElement
    {
        private readonly List<IniOption> items = new List<IniOption>();

        public IniOption this[string name] 
        {
            get => this.Get(name); 
            set => Set(value.Name != null ? new IniOption(name, value.ValueText) : value);
        }
        public IniOption this[int index]
        {
            get => items[index];
            set => items[index] = value;
        }

        public int Count => items.Count;

        bool ICollection<IniOption>.IsReadOnly => false;

        public void Add(IniOption option)
            => items.Add(option ?? throw new ArgumentNullException(nameof(option)));

        public void Clear()
            => items.Clear();

        public bool Contains(IniOption item)
            => items.Contains(item);

        public void CopyTo(IniOption[] array, int arrayIndex)
            => items.CopyTo(array, arrayIndex);

        public IEnumerable<IniOption> GetAll()
            => items;

        public IEnumerator<IniOption> GetEnumerator()
            => items.GetEnumerator();

        public int IndexOf(IniOption item)
            => items.IndexOf(item ?? throw new ArgumentNullException(nameof(item)));

        public void Insert(int index, IniOption item)
        {
            _ = item ?? throw new ArgumentNullException(nameof(item));
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            items.Insert(index, item);
        }

        public void Remove(string name)
            => items.RemoveAll(x => x.Name == name);

        public bool Remove(IniOption item)
            => items.Remove(item);

        public void RemoveAt(int index)
            => items.RemoveAt(index);

        public void Set(IniOption option)
        {
            _ = option ?? throw new ArgumentNullException(nameof(option));
            var old = this.Get(option.Name);
            var index = old != null ? items.IndexOf(old) : -1;
            if (index < 0)
                items.Add(option);
            else items[index] = option;
        }

        public void Write(TextWriter writer, WriteOptions options)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            _ = options ?? throw new ArgumentNullException(nameof(options));
            bool first = true;
            foreach (var item in items)
            {
                if (first)
                    first = false;
                else if (options.WriteAsAttributes)
                    writer.Write(";");
                item.Write(writer, options);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}