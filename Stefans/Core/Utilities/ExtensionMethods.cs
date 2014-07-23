using System;
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
    }
}
