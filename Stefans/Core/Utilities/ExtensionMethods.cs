﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
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

        public static string JoinStrings<T>(this IEnumerable<T> Strings, string Separator = "")
        {
            return string.Join(Separator, Strings);
        }

        public static string WrapWithCData(this object Obj)
        {
            return Obj != null ? string.Format("<![CDATA[{0}]]>", Obj) : string.Empty;
        }

        public static IEnumerable<XElement> Children(this XElement XElement, params string[] Tags)
        {
            return new[] { XElement }.Children(Tags);
        }

        public static IEnumerable<XElement> Children(this IEnumerable<XElement> Elements, params string[] Tags)
        {
            return Tags.Aggregate(Elements, (current, tag) => current.Elements(tag));
        }
    }
}
