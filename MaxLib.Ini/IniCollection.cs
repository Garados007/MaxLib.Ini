using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MaxLib.Ini
{
    public class IniCollection : IIniCollection<IIniGroupItem>, IIniElement
    {
        private readonly List<IIniGroupItem> items = new List<IIniGroupItem>();

        public IniOption this[string name] 
        {
            get => this.Get(name); 
            set => Set(value.Name != null ? new IniOption(name, value.ValueText) : value);
        }
        public IIniGroupItem this[int index] 
        { 
            get => items[index];
            set => items[index] = value;
        }

        public int Count => items.Count;

        bool ICollection<IIniGroupItem>.IsReadOnly => false;

        public void Add(IniOption option)
            => Add(option ?? throw new ArgumentNullException(nameof(option)));

        public void Add(IIniGroupItem item)
        {
            _ = item ?? throw new ArgumentNullException(nameof(item));
            items.Add(item);
        }

        public void Clear()
            => items.Clear();

        public bool Contains(IIniGroupItem item)
            => items.Contains(item);

        public void CopyTo(IIniGroupItem[] array, int arrayIndex)
            => items.CopyTo(array, arrayIndex);

        public IEnumerable<IniOption> GetAll()
            => items.Where(x => x is IniOption)
                .Cast<IniOption>();

        public IEnumerator<IIniGroupItem> GetEnumerator()
            => items.GetEnumerator();

        public int IndexOf(IIniGroupItem item)
            => items.IndexOf(item);

        public void Insert(int index, IIniGroupItem item)
        {
            _ = items ?? throw new ArgumentNullException(nameof(item));
            if (index < 0 || index > items.Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            items.Insert(index, item);
        }

        public void Remove(string name)
        {
            items.RemoveAll(
                x => x is IniOption option && option.Name == name
            );
        }

        public bool Remove(IIniGroupItem item)
            => items.Remove(item);

        public void RemoveAt(int index)
            => items.RemoveAt(index);

        public void Set(IniOption option)
        {
            _ = option ?? throw new ArgumentNullException(nameof(option));
            var old = this.Get(option.Name);
            if (old != null) 
            {
                var index = items.IndexOf(old);
                items[index] = option;
            }
            else items.Add(option);
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public void RemoveComments()
        {
            items.RemoveAll(x => x is IniComment);
        }

        public void Write(TextWriter writer, WriteOptions options)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            _ = options ?? throw new ArgumentNullException(nameof(options));
            foreach (var item in items)
            {
                item.Write(writer, options);
            }
        }
    }
}