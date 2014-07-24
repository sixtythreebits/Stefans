using System.Collections.Generic;

namespace Core.Utilities
{
    public class Utility
    {
        public static readonly IReadOnlyList<string> AllowedImageExtensions = new List<string>(4) { ".jpg", ".jpeg", ".gif", ".png" };
    }
}
