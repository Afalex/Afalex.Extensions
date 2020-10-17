using System;
using System.Collections.Generic;
using System.Text;

namespace Afalex.Extensions.Internal
{
    public static class LinqExt
    {
        public static void ForAll<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var feature in enumerable)
            {
                action(feature);
            }
        }
    }
}
