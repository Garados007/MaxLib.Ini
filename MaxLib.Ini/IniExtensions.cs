using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;
namespace MaxLib.Ini
{
    public static class IniExtensions
    {
        public static IniOption GetOrAdd<T>(this IIniCollection<T> collection, string key)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            if (item == null)
                collection.Add(item = new IniOption(key));
            return item;
        }

        public static IniOption Get<T>(this IIniCollection<T> collection, string name)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = name ?? throw new ArgumentNullException(nameof(name));
            return collection.GetAll(name).FirstOrDefault();
        }

        public static IEnumerable<IniOption> GetAll<T>(this IIniCollection<T> collection, string name)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = name ?? throw new ArgumentNullException(nameof(name));
            return collection.GetAll().Where(x => x.Name == name);
        }

        public static string GetString<T>(this IIniCollection<T> collection, string key, string @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.String : @default;
        }

        public static void SetString<T>(this IIniCollection<T> collection, string key, string value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).String = value;
        }

        public static bool GetBool<T>(this IIniCollection<T> collection, string key, bool @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.Bool : @default;
        }

        public static void SetBool<T>(this IIniCollection<T> collection, string key, bool value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).Bool = value;
        }

        public static byte GetByte<T>(this IIniCollection<T> collection, string key, byte @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.Byte : @default;
        }

        public static void SetByte<T>(this IIniCollection<T> collection, string key, byte value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).Byte = value;
        }

        public static sbyte GetSByte<T>(this IIniCollection<T> collection, string key, sbyte @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.SByte : @default;
        }

        public static void SetSByte<T>(this IIniCollection<T> collection, string key, sbyte value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).SByte = value;
        }

        public static short GetInt16<T>(this IIniCollection<T> collection, string key, short @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.Int16 : @default;
        }

        public static void SetInt16<T>(this IIniCollection<T> collection, string key, short value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).Int16 = value;
        }

        public static ushort GetUInt16<T>(this IIniCollection<T> collection, string key, ushort @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.UInt16 : @default;
        }

        public static void SetUInt16<T>(this IIniCollection<T> collection, string key, ushort value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).UInt16 = value;
        }

        public static int GetInt32<T>(this IIniCollection<T> collection, string key, int @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.Int32 : @default;
        }

        public static void SetInt32<T>(this IIniCollection<T> collection, string key, int value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).Int32 = value;
        }

        public static uint GetUInt32<T>(this IIniCollection<T> collection, string key, uint @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.UInt32 : @default;
        }

        public static void SetUInt32<T>(this IIniCollection<T> collection, string key, uint value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).UInt32 = value;
        }

        public static long GetInt64<T>(this IIniCollection<T> collection, string key, long @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.Int64 : @default;
        }

        public static void SetInt64<T>(this IIniCollection<T> collection, string key, long value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).Int64 = value;
        }

        public static ulong GetUInt64<T>(this IIniCollection<T> collection, string key, ulong @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.UInt64 : @default;
        }

        public static void SetUInt64<T>(this IIniCollection<T> collection, string key, ulong value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).UInt64 = value;
        }

        public static float GetSingle<T>(this IIniCollection<T> collection, string key, float @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.Single : @default;
        }

        public static void SetSingle<T>(this IIniCollection<T> collection, string key, float value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).Single = value;
        }

        public static double GetDouble<T>(this IIniCollection<T> collection, string key, double @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.Double : @default;
        }

        public static void SetDouble<T>(this IIniCollection<T> collection, string key, double value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).Double = value;
        }

        public static decimal GetDecimal<T>(this IIniCollection<T> collection, string key, decimal @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.Decimal : @default;
        }

        public static void SetDecimal<T>(this IIniCollection<T> collection, string key, decimal value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).Decimal = value;
        }

        public static char GetChar<T>(this IIniCollection<T> collection, string key, char @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.Char : @default;
        }

        public static void SetChar<T>(this IIniCollection<T> collection, string key, char value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).Char = value;
        }

        public static Guid GetGuid<T>(this IIniCollection<T> collection, string key, Guid @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.Guid : @default;
        }

        public static void SetGuid<T>(this IIniCollection<T> collection, string key, Guid value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).Guid = value;
        }

        public static DateTime GetDateTime<T>(this IIniCollection<T> collection, string key, DateTime @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.DateTime : @default;
        }

        public static void SetDateTime<T>(this IIniCollection<T> collection, string key, DateTime value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).DateTime = value;
        }

        public static TimeSpan GetTimeSpan<T>(this IIniCollection<T> collection, string key, TimeSpan @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.TimeSpan : @default;
        }

        public static void SetTimeSpan<T>(this IIniCollection<T> collection, string key, TimeSpan value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).TimeSpan = value;
        }

        public static Enum GetEnum<T, Enum>(this IIniCollection<T> collection, string key, Enum @default)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.GetEnum<Enum>() : @default;
        }

        public static void SetEnum<T, Enum>(this IIniCollection<T> collection, string key, Enum value)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).SetEnum(value);
        }

        public static byte[] GetBytes<T>(this IIniCollection<T> collection, string key, BinaryMode mode = BinaryMode.Base64)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            var item = collection.Get(key);
            return item != null ? item.GetBytes(mode) : new byte[0];
        }

        public static void SetBytes<T>(this IIniCollection<T> collection, string key, byte[] value, BinaryMode mode = BinaryMode.Base64)
            where T : IIniGroupItem
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            _ = key ?? throw new ArgumentNullException(nameof(key));
            collection.GetOrAdd(key).SetBytes(value ?? new byte[0], mode);
        }
    }
}
