using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Utilities
{
    public static class ExtensionMethods
    {
        public static string ToJson(this object Obj, Formatting Formatting = Formatting.None)
        {
            return JsonConvert.SerializeObject(Obj, Formatting);
        }

        public static TimeSpan Minutes(this int Quantity)
        {
            return TimeSpan.FromMinutes(Quantity);
        }

        public static string JoinStrings(this IEnumerable<string> Strings, string Separator = "")
        {
            return string.Join(Separator, Strings);
        }

        public static string WrapWithCData(this object Obj)
        {
            return Obj != null ? string.Format("<![CDATA[{0}]]>", Obj) : string.Empty;
        }
    }
}
