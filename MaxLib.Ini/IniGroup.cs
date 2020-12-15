using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MaxLib.Ini
{
    public class IniGroup : IIniCollection<IIniGroupItem>, IIniElement
    {
        public string Name { get; set; }

        public bool IsRoot => Name == null;

        public OptionCollection Attributes { get; }
            = new OptionCollection();

        public IniCollection Elements { get; }
            = new IniCollection();

        public IniGroup(string name = null)
        {
            Name = name;
        }

        #region wrapper for Elements

        public IniOption this[string name] { get => ((IIniCollection<IIniGroupItem>)Elements)[name]; set => ((IIniCollection<IIniGroupItem>)Elements)[name] = value; }
        public IIniGroupItem this[int index] { get => ((IList<IIniGroupItem>)Elements)[index]; set => ((IList<IIniGroupItem>)Elements)[index] = value; }

        public int Count => ((ICollection<IIniGroupItem>)Elements).Count;

        bool ICollection<IIniGroupItem>.IsReadOnly => false;
        
        public void Add(IniOption option)
        {
            ((IIniCollection<IIniGroupItem>)Elements).Add(option);
        }

        public void Add(IIniGroupItem item)
        {
            ((ICollection<IIniGroupItem>)Elements).Add(item);
        }

        public void Clear()
        {
            ((ICollection<IIniGroupItem>)Elements).Clear();
        }

        public bool Contains(IIniGroupItem item)
        {
            return ((ICollection<IIniGroupItem>)Elements).Contains(item);
        }

        public void CopyTo(IIniGroupItem[] array, int arrayIndex)
        {
            ((ICollection<IIniGroupItem>)Elements).CopyTo(array, arrayIndex);
        }

        public IEnumerable<IniOption> GetAll()
        {
            return ((IIniCollection<IIniGroupItem>)Elements).GetAll();
        }

        public IEnumerator<IIniGroupItem> GetEnumerator()
        {
            return ((IEnumerable<IIniGroupItem>)Elements).GetEnumerator();
        }

        public int IndexOf(IIniGroupItem item)
        {
            return ((IList<IIniGroupItem>)Elements).IndexOf(item);
        }

        public void Insert(int index, IIniGroupItem item)
        {
            ((IList<IIniGroupItem>)Elements).Insert(index, item);
        }

        public void Remove(string name)
        {
            ((IIniCollection<IIniGroupItem>)Elements).Remove(name);
        }

        public bool Remove(IIniGroupItem item)
        {
            return ((ICollection<IIniGroupItem>)Elements).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<IIniGroupItem>)Elements).RemoveAt(index);
        }

        public void Set(IniOption option)
        {
            ((IIniCollection<IIniGroupItem>)Elements).Set(option);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Elements).GetEnumerator();
        }

        #endregion wrapper for Elements

        public void Write(TextWriter writer, WriteOptions options)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            _ = options ?? throw new ArgumentNullException(nameof(options));
            if (!IsRoot)
            {
                writer.Write("[");
                writer.Write(Tools.ValidateNameString(Name));
                if (Attributes.Count > 0)
                {
                    var opt = options.Clone();
                    opt.WriteAsAttributes = true;
                    Attributes.Write(writer, opt);
                }
                writer.WriteLine("]");
            }
            Elements.Write(writer, options);
        }

    }
}