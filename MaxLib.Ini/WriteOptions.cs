using System;
namespace MaxLib.Ini
{
    public class WriteOptions : ICloneable
    {
        /// <summary>
        /// The keys should be written as inline attributes for groups
        /// </summary>
        public bool WriteAsAttributes { get; set; } = false;

        public virtual WriteOptions Clone()
        {
            return new WriteOptions
            {
                WriteAsAttributes = WriteAsAttributes,
            };
        }

        object ICloneable.Clone()
            => Clone();

        
    }
}