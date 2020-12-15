using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MaxLib.Ini
{
    public class IniFile : IList<IniGroup>, IIniElement
    {
        private readonly List<IniGroup> groups 
            = new List<IniGroup>
            {   
                new IniGroup(),
            };

        #region IList<IniGroup> member

        public IniGroup this[int index] 
        { 
            get => groups[index]; 
            set 
            {
                _ = value ?? throw new ArgumentNullException(nameof(value));
                if (index <=0 || index >= groups.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                groups[index] = value;
            } 
        }

        public int Count => groups.Count;

        bool ICollection<IniGroup>.IsReadOnly => false;

        public void Add(IniGroup item)
        {
            groups.Add(item ?? throw new ArgumentNullException(nameof(item)));
        }

        public void Clear()
        {
            groups.Clear();
            groups.Add(new IniGroup());
        }

        public bool Contains(IniGroup item)
            => groups.Contains(item);

        public void CopyTo(IniGroup[] array, int arrayIndex)
            => groups.CopyTo(array, arrayIndex);

        public IEnumerator<IniGroup> GetEnumerator()
            => groups.GetEnumerator();

        public int IndexOf(IniGroup item)
            => groups.IndexOf(item);

        public void Insert(int index, IniGroup item)
        {
            _ = item ?? throw new ArgumentNullException(nameof(item));
            if (index < 0 || index > groups.Count)
                throw new ArgumentOutOfRangeException(nameof(item));
            groups.Insert(index, item);
        }

        public bool Remove(IniGroup item)
            => groups.Remove(item);

        public void RemoveAt(int index)
            => groups.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        #endregion IList<IniGroup> member
    
        public IEnumerable<IniGroup> GetGroups(string name)
            => groups.Where(x => x.Name == name);

        public IniGroup GetGroup(string name)
            => GetGroups(name).FirstOrDefault();

        public IniGroup this[string name]
        {
            get => GetGroup(name);
            set
            {
                _ = value ?? throw new ArgumentNullException(nameof(value));
                value.Name = name;
                var index = groups.FindIndex(x => x.Name == name);
                if (index < 0)
                    Add(value);
                else groups[index] = value;
            }
        }

        public void Set(IniGroup group)
        {
            _ = group ?? throw new ArgumentNullException(nameof(group));
            var first = GetGroup(group.Name);
            var index = first != null ? groups.IndexOf(first) : -1;
            if (index < 0)
                groups.Add(group);
            else groups[index] = group;
        }

        public virtual string Write(WriteOptions options = null)
        {
            using var stream = new MemoryStream();
            Write(stream, Encoding.UTF8, options);
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public virtual void Write(string path, Encoding encoding = null, WriteOptions options = null)
        {
            _ = path ?? throw new ArgumentException(nameof(path));
            using var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
            Write(stream, encoding, options);
        }

        public virtual void Write(Stream stream, Encoding encoding = null, WriteOptions options = null)
        {
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
            if (!stream.CanWrite)
                throw new ArgumentException("stream is not writeable", nameof(stream));
            encoding ??= Encoding.UTF8;
            using var writer = new StreamWriter(stream, encoding, 1024, true);
            Write(writer, options);
        }

        public virtual void Write(TextWriter writer, WriteOptions options = null)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            options ??= new WriteOptions();
            if (!HasValidRoot)
                throw new InvalidOperationException("this file has no valid root");
            if (!HasValidGroups)
                throw new InvalidOperationException("this file has a non valid group");
            foreach (var group in groups)
                group.Write(writer, options);
        }



        /// <summary>
        /// Detects if the first group is a root group and therefore valid
        /// </summary>
        public bool HasValidRoot
            => groups.Count > 0 && groups[0].IsRoot;
        
        /// <summary>
        /// Detects if all but first groups are not a root group and therefore valid
        /// </summary>
        public bool HasValidGroups
            => groups
                .Skip(1)
                .All(x => !x.IsRoot);
    }
}