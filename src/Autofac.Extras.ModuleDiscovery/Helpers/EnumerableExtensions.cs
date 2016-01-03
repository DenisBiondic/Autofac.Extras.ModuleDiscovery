using System;
using System.Collections.Generic;

namespace Autofac.Extras.ModuleDiscovery.Helpers
{
    public static class EnumerableExtensions
    {
        internal static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}