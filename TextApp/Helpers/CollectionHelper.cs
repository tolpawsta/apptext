using System.Collections.Generic;

namespace TextApp.Helpers
{
    static class CollectionHelper
    {
        public static void AddRange<T>(this ICollection<T> destination,
            IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                destination.Add(item);
            }
        }
    }
}
