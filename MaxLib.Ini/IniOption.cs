using System.Text;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.IO;

namespace MaxLib.Ini
{
    [Serializable]
    public class IniOption : IIniElement, IIniGroupItem
    {
        private string name;
        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }

        private string valueText;
        public string ValueText
        {
            get => valueText;
            set => valueText = value ?? throw new ArgumentNullException(nameof(value));
        }

        public IniOption(string name, string valueText = "")
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            ValueText = valueText ?? "";
        }

        private static NumberFormatInfo NumberFormat
            => CultureInfo.InvariantCulture.NumberFormat;

        private static DateTimeFormatInfo DateTimeFormat
            => CultureInfo.InvariantCulture.DateTimeFormat;

        public string String
        {
            get => Tools.ToValueString(ValueText);
            set => ValueText = Tools.ToFileString(value);
        }

        public bool Bool
        {
            get => bool.Parse(ValueText);
            set => ValueText = value.ToString().ToLower();
        }

        public byte Byte
        {
            get => byte.Parse(ValueText, NumberFormat);
            set => ValueText = value.ToString(NumberFormat);
        }

        public sbyte SByte
        {
            get => sbyte.Parse(ValueText, NumberFormat);
            set => ValueText = value.ToString(NumberFormat);
        }

        public short Int16
        {
            get => short.Parse(ValueText, NumberFormat);
            set => ValueText = value.ToString(NumberFormat);
        }

        public ushort UInt16
        {
            get => ushort.Parse(ValueText, NumberFormat);
            set => ValueText = value.ToString(NumberFormat);
        }

        public int Int32
        {
            get => int.Parse(ValueText, NumberFormat);
            set => ValueText = value.ToString(NumberFormat);
        }

        public uint UInt32
        {
            get => uint.Parse(ValueText, NumberFormat);
            set => ValueText = value.ToString(NumberFormat);
        }

        public long Int64
        {
            get => long.Parse(ValueText, NumberFormat);
            set => ValueText = value.ToString(NumberFormat);
        }

        public ulong UInt64
        {
            get => ulong.Parse(ValueText, NumberFormat);
            set => ValueText = value.ToString(NumberFormat);
        }

        public float Single
        {
            get => float.Parse(ValueText, NumberFormat);
            set => ValueText = value.ToString(NumberFormat);
        }

        public double Double
        {
            get => double.Parse(ValueText, NumberFormat);
            set => ValueText = value.ToString(NumberFormat);
        }

        public decimal Decimal
        {
            get => decimal.Parse(ValueText, NumberFormat);
            set => ValueText = value.ToString(NumberFormat);
        }

        public char Char
        {
            get => (char)Int32;
            set => Int32 = (int)value;
        }

        public Guid Guid
        {
            get => Guid.Parse(ValueText);
            set => ValueText = value.ToString();
        }

        public DateTime DateTime
        {
            get => DateTime.Parse(ValueText, DateTimeFormat);
            set => ValueText = value.ToString(DateTimeFormat);
        }

        public TimeSpan TimeSpan
        {
            get => TimeSpan.Parse(ValueText, DateTimeFormat);
            set => ValueText = value.ToString(null, DateTimeFormat);
        }

        public T GetEnum<T>()
        {
            if (!typeof(T).IsSubclassOf(typeof(Enum)))
                throw new FormatException("the argument type is not an Enum");
            return (T)Enum.Parse(typeof(T), ValueText);
        }

        public void SetEnum<T>(T value)
        {
            if (!typeof(T).IsSubclassOf(typeof(Enum)))
                throw new FormatException("the argument type is not an Enum");
            ValueText = value.ToString();
        }

        public byte[] GetBytes(BinaryMode mode = BinaryMode.Base64)
        {
            switch (mode)
            {
                case BinaryMode.Base64:
                    return Convert.FromBase64String(ValueText);
                case BinaryMode.Hex:
                {
                    const string hex = "0123456789abcdef";
                    var l = new List<byte>(ValueText.Length / 2);
                    var value = ValueText.ToLower();
                    var nibble = 0;
                    var hasLower = false;
                    for (int i = 0; i< value.Length; ++i)
                    {
                        var index = hex.IndexOf(value[i]);
                        if (index < 0)
                            continue;
                        nibble = (nibble << 4) | index;
                        hasLower = !hasLower;
                        if (!hasLower)
                        {
                            l.Add((byte)nibble);
                            nibble = 0;
                        }
                    }
                    return l.ToArray();
                }
                default:
                    throw new NotImplementedException($"mode {mode} is not supported");
            }
        }

        public void SetBytes(byte[] bytes, BinaryMode mode = BinaryMode.Base64)
        {
            _ = bytes ?? throw new ArgumentNullException(nameof(bytes));
            switch (mode)
            {
                case BinaryMode.Base64:
                    ValueText = Convert.ToBase64String(bytes);
                    break;
                case BinaryMode.Hex:
                {
                    const string hex = "0123456789abcdef";
                    var sb = new StringBuilder(bytes.Length * 2);
                    for (int i = 0; i < bytes.Length; ++i)
                    {
                        sb.Append(hex[bytes[i] >> 4]);
                        sb.Append(hex[bytes[i] & 0x0f]);
                    }
                    ValueText = sb.ToString();
                } break;
                default:
                    throw new NotImplementedException($"mode {mode} is not supported");
            }
        }

        public void Write(TextWriter writer, WriteOptions options)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            _ = options ?? throw new ArgumentNullException(nameof(options));
            writer.Write(Tools.ValidateNameString(Name));
            writer.Write("=");
            if (options.WriteAsAttributes)
            {
                writer.Write(Tools.ToFileString(ValueText));
            }
            else
            {
                writer.WriteLine(Tools.ToFileString(ValueText));
            }
        }

        public override string ToString()
        {
            return $"{Tools.ValidateNameString(Name)}={ValueText}";
        }
    }
}
