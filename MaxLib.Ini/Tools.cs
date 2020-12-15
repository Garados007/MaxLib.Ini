using System.Linq;
using System.Text;

namespace MaxLib.Ini
{
    public static class Tools
    {
        static readonly string[] repl = new[]
            {
                "\\", "\\\\",
                "\"", "\\\"",
                "\t", "\\t",
                "\r", "\\r",
                "\n", "\\n",
                "(",  "\\(",
                ")",  "\\)",
                ";",  "\\;",
            };

        public static string ToFileString(string valueString)
        {
            var sb = new StringBuilder(valueString);
            for (int i = 0; i < repl.Length; i += 2) 
                sb.Replace(repl[i], repl[i + 1]);
            if (sb.Length == valueString.Length) // not changed at all
                return valueString;
            sb.Insert(0, '\"');
            sb.Append('\"');
            return sb.ToString();
        }

        public static string ToValueString(string fileString)
        {
            if (fileString == "\"\"" || fileString == "")
                return "";
            var sb = new StringBuilder();
            for (int i = 1; i < fileString.Length - 1; ++i)
                if (fileString[i] == '\\' && i < fileString.Length - 2)
                {
                    var part = "" + fileString[i] + fileString[i + 1];
                    if (repl.Contains(part))
                    {
                        var ind = 0;
                        for (; ind < repl.Length; ind += 2)
                            if (repl[ind + 1] == part)
                                break;
                        sb.Append(repl[ind]);
                        i++;
                    }
                }
                else sb.Append(fileString[i]);
            return sb.ToString();
        }

        const string markers = "=";

        public static string ValidateNameString(string name)
        {
            for (int i = 0; i < markers.Length; ++i)
                if (name.Contains(markers[i]))
                return ToFileString(name);
            for (int i = 0; i < repl.Length; i += 2)
                if (name.Contains(repl[i]))
                    return ToFileString(name);
            return name;
        }

        public static string ResolveValidationName(string name)
        {
            if (name.StartsWith("\""))
                return ToValueString(name);
            return name;
        }
    }
}